namespace ClassIsland.Shared.Abstraction.Models;

/// <summary>
/// 提醒提供方设置接口
/// </summary>
public interface INotificationSettings
{
    /// <summary>
    /// 是否启用提醒
    /// </summary>
    public bool IsNotificationEnabled
    {
        get;
        set;
    }

    /// <summary>
    /// 是否启用语音
    /// </summary>
    public bool IsSpeechEnabled
    {
        get;
        set;
    }

    /// <summary>
    /// 是否启用提醒效果
    /// </summary>
    public bool IsNotificationEffectEnabled
    {
        get;
        set;
    }

    /// <summary>
    /// 是否启用提醒音效
    /// </summary>
    public bool IsNotificationSoundEnabled
    {
        get;
        set;
    }

    /// <summary>
    /// 提醒音效路径
    /// </summary>
    public string NotificationSoundPath
    {
        get;
        set;
    }

    /// <summary>
    /// 是否在提醒时置顶主界面
    /// </summary>
    public bool IsNotificationTopmostEnabled
    {
        get;
        set;
    }

    /// <summary>
    /// 是否在提醒时强制修改音频设置
    /// </summary>
    public bool IsNotificationForceAudioSettingEnabled
    {
        get;
        set;
    }

    /// <summary>
    /// 是否在提醒时强制修改音频设置-音量
    /// </summary>
    public bool IsNotificationForceAudioSettingVolumeEnabled
    {
        get;
        set;
    }

    /// <summary>
    /// 是否在提醒时强制修改音频设置-自动恢复音量
    /// </summary>
    public bool IsNotificationForceAudioSettingVolumeAutoUndoEnabled
    {
        get;
        set;
    }

    /// <summary>
    /// 在提醒时强制修改音频设置-音量大小
    /// </summary>
    public double NotificationForceAudioSettingVolume
    {
        get;
        set;
    }

    /// <summary>
    /// 是否在提醒时强制修改音频设置-设备
    /// </summary>
    public bool IsNotificationForceAudioSettingDeviceEnabled
    {
        get;
        set;
    }

    /// <summary>
    /// 在提醒时强制修改音频设置-设备
    /// </summary>
    public Guid NotificationForceAudioSettingDevice
    {
        get;
        set;
    }

    /// <summary>
    /// 是否在提醒时强制修改音频设置-默认设备
    /// </summary>
    public bool IsNotificationForceAudioSettingDefaultDeviceEnabled
    {
        get;
        set;
    }
}