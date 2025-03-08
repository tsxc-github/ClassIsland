using ClassIsland.Shared.Abstraction.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ClassIsland.Shared.Models.Notification;

/// <summary>
/// 提醒设置
/// </summary>
public class NotificationSettings : ObservableRecipient, INotificationSettings
{
    private bool _isNotificationEnabled = true;
    private bool _isSpeechEnabled = false;
    private bool _isNotificationEffectEnabled = true;
    private bool _isNotificationSoundEnabled = false;
    private string _notificationSoundPath = "";
    private bool _isSettingsEnabled = false;
    private bool _isNotificationTopmostEnabled = false;
    private bool _isNotificationForceAudioSettingEnabled = false;
    private bool _isNotificationForceAudioSettingVolumeEnabled = false;
    private double _notificationForceAudioSettingVolume = 0.5;
    private bool _isNotificationForceAudioSettingVolumeAutoUndoEnabled = false;
    private bool _isNotificationForceAudioSettingDeviceEnabled = false;
    private bool _isNotificationForceAudioSettingDefaultDeviceEnabled = false;
    private Guid _notificationForceAudioSettingDevice = Guid.Empty;

    /// <summary>
    /// 是否启用提醒
    /// </summary>
    public bool IsNotificationEnabled
    {
        get => _isNotificationEnabled;
        set
        {
            if (value == _isNotificationEnabled) return;
            _isNotificationEnabled = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 是否启用语音
    /// </summary>
    public bool IsSpeechEnabled
    {
        get => _isSpeechEnabled;
        set
        {
            if (value == _isSpeechEnabled) return;
            _isSpeechEnabled = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 是否启用提醒效果
    /// </summary>
    public bool IsNotificationEffectEnabled
    {
        get => _isNotificationEffectEnabled;
        set
        {
            if (value == _isNotificationEffectEnabled) return;
            _isNotificationEffectEnabled = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 是否启用提醒音效
    /// </summary>
    public bool IsNotificationSoundEnabled
    {
        get => _isNotificationSoundEnabled;
        set
        {
            if (value == _isNotificationSoundEnabled) return;
            _isNotificationSoundEnabled = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 提醒音效路径
    /// </summary>
    public string NotificationSoundPath
    {
        get => _notificationSoundPath;
        set
        {
            if (value == _notificationSoundPath) return;
            _notificationSoundPath = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 是否在提醒时置顶主界面
    /// </summary>
    public bool IsNotificationTopmostEnabled
    {
        get => _isNotificationTopmostEnabled;
        set
        {
            if (value == _isNotificationTopmostEnabled) return;
            _isNotificationTopmostEnabled = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 是否在提醒时强制修改音频设置
    /// </summary>
    public bool IsNotificationForceAudioSettingEnabled
    {
        get => _isNotificationForceAudioSettingEnabled;
        set
        {
            if (value == _isNotificationForceAudioSettingEnabled) return;
            _isNotificationForceAudioSettingEnabled = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 是否在提醒时强制修改音频设置-音量
    /// </summary>
    public bool IsNotificationForceAudioSettingVolumeEnabled
    {
        get => _isNotificationForceAudioSettingVolumeEnabled;
        set
        {
            if (value == _isNotificationForceAudioSettingVolumeEnabled) return;
            _isNotificationForceAudioSettingVolumeEnabled = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 在提醒时强制修改音频设置-音量大小
    /// </summary>
    public double NotificationForceAudioSettingVolume
    {
        get => _notificationForceAudioSettingVolume;
        set
        {
            if (value.Equals(_notificationForceAudioSettingVolume)) return;
            _notificationForceAudioSettingVolume = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 在提醒时强制修改音频设置-自动恢复音量
    /// </summary>
    public bool IsNotificationForceAudioSettingVolumeAutoUndoEnabled
    {
        get => _isNotificationForceAudioSettingVolumeAutoUndoEnabled;
        set
        {
            if (value == _isNotificationForceAudioSettingVolumeAutoUndoEnabled) return;
            _isNotificationForceAudioSettingVolumeAutoUndoEnabled = value;
            OnPropertyChanged();
        }
    }
    /// <summary>
    /// 在提醒时强制修改音频设置-是否更改设备
    /// </summary>
    public bool IsNotificationForceAudioSettingDeviceEnabled
    {
        get => _isNotificationForceAudioSettingDeviceEnabled;
        set
        {
            if (value.Equals(_isNotificationForceAudioSettingDeviceEnabled)) return;
            _isNotificationForceAudioSettingDeviceEnabled = value;
            OnPropertyChanged();
        }
    }
    /// <summary>
    /// 在提醒时强制修改音频设置-是否更改默认设备
    /// </summary>
    public bool IsNotificationForceAudioSettingDefaultDeviceEnabled
    {
        get => _isNotificationForceAudioSettingDefaultDeviceEnabled;
        set
        {
            if (value.Equals(_isNotificationForceAudioSettingDefaultDeviceEnabled)) return;
            _isNotificationForceAudioSettingDefaultDeviceEnabled = value;
            OnPropertyChanged();
        }
    }
    /// <summary>
    /// 在提醒时强制修改音频设置-设备
    /// </summary>
    public Guid NotificationForceAudioSettingDevice
    {
        get => _notificationForceAudioSettingDevice;
        set
        {
            if (value.Equals(_notificationForceAudioSettingDevice)) return;
            _notificationForceAudioSettingDevice = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 是否启用此提醒设置。如果为false，那么这里设置的提醒设置将不起作用。
    /// </summary>
    public bool IsSettingsEnabled
    {
        get => _isSettingsEnabled;
        set
        {
            if (value == _isSettingsEnabled) return;
            _isSettingsEnabled = value;
            OnPropertyChanged();
        }
    }
}