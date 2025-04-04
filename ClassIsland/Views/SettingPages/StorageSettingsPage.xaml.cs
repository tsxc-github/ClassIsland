﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassIsland.Core;
using ClassIsland.Core.Abstractions.Services.Management;
using ClassIsland.Core.Attributes;
using ClassIsland.Core.Enums.SettingsWindow;
using ClassIsland.Services;
using ClassIsland.Services.Management;
using ClassIsland.ViewModels.SettingsPages;
using Grpc.Core.Logging;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using CommonDialog = ClassIsland.Core.Controls.CommonDialog.CommonDialog;
using Path = System.IO.Path;

namespace ClassIsland.Views.SettingPages;

/// <summary>
/// StorageSettingsPage.xaml 的交互逻辑
/// </summary>
[SettingsPageInfo("storage", "存储", PackIconKind.DatabaseOutline, PackIconKind.Database, SettingsPageCategory.Internal)]
public partial class StorageSettingsPage
{
    public StorageSettingsViewModel ViewModel { get; } = new();

    public FileFolderService FileFolderService { get; }
    public SettingsService SettingsService { get; }
    public ILogger<StorageSettingsPage> Logger { get; }
    public IManagementService ManagementService { get; }

    public StorageSettingsPage(FileFolderService fileFolderService, SettingsService settingsService, ILogger<StorageSettingsPage> logger, IManagementService managementService)
    {
        FileFolderService = fileFolderService;
        SettingsService = settingsService;
        Logger = logger;
        ManagementService = managementService;
        DataContext = this;
        InitializeComponent();
    }

    private async void ButtonCreateBackup_OnClick(object sender, RoutedEventArgs e)
    {
        ViewModel.IsBackupFinished = false;
        ViewModel.IsBackingUp = true;
        try
        {
            await FileFolderService.CreateBackupAsync();
            ViewModel.IsBackupFinished = true;
        }
        catch (Exception exception)
        {
            Logger.LogError(exception, "无法创建备份。");
            CommonDialog.ShowError($"无法创建备份：{exception.Message}");
        }
        ViewModel.IsBackingUp = false;
    }

    private void ButtonViewBackupFiles_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = System.IO.Path.GetFullPath(Path.Combine(App.AppRootFolderPath, "Backups")),
                UseShellExecute = true
            });
        }
        catch (Exception exception)
        {
            Logger.LogError(exception, "无法浏览备份文件。");
            CommonDialog.ShowError($"无法浏览备份文件：{exception.Message}");
        }
    }

    private async void ButtonRecoverBackup_OnClick(object sender, RoutedEventArgs e)
    {
        if (!await ManagementService.AuthorizeByLevel(ManagementService.CredentialConfig.ExitApplicationAuthorizeLevel))
        {
            return;
        }
        AppBase.Current.Restart(["-m", "-r"]);
    }
}