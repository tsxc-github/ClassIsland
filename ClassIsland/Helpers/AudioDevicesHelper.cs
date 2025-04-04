using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudioSwitcher.AudioApi.CoreAudio;
using CSCore.CoreAudioAPI;
using Microsoft.Extensions.Logging;

namespace ClassIsland.Helpers;

public class AudioDevicesHelper
{
    /// <summary>
    /// 获得输入设备
    /// </summary>
    /// <returns>返回一个Dictionary，key为设备ID，value为设备FullName</returns>
    public static Dictionary<string, string> GetNameOfPlaybackDevices()
    {
        using (var enumerator = new CoreAudioController())
        {
            return enumerator.GetDevices().ToDictionary(key => key.RealId, value => value.FullName);
        }
    }

    /// <summary>
    /// 获得所有的设备，包括输入输出
    /// </summary>
    /// <returns>返回一个Dictionary，key为设备ID，value为设备，注意类型为MMDevice</returns>
    public static Dictionary<string, MMDevice> GetDevices()
    {
        using (var enumerator = new MMDeviceEnumerator())
        {
            return enumerator.EnumAudioEndpoints(DataFlow.Render, CSCore.CoreAudioAPI.DeviceState.Active)
                .ToDictionary(key => key.DeviceID, value => value);
        }
    }

    /// <summary>
    /// 获得输出设备
    /// </summary>
    /// <returns>返回一个Dictionary，key为设备ID，value为设备，注意类型为CoreAudioDevice</returns>
    private static Dictionary<string, CoreAudioDevice> GetCoreAudioDevice()
    {
        using (var enumerator = new CoreAudioController())
        {
            return enumerator.GetDevices().ToDictionary(key => key.RealId, value => value);
        }
    }

    /// <summary>
    /// 通过设备ID获得输出设备
    /// </summary>
    /// <param name="id">设备ID</param>
    /// <returns>返回一个设备</returns>
    public static MMDevice GetDeviceById(string id)
    {
        return GetDevices()[id];
    }

    /// <summary>
    /// 设置音量大小
    /// </summary>
    /// <param name="id">设备ID</param>
    /// <param name="volume">音量大小(0~1)</param>
    /// <returns></returns>
    public static void SetDeviceVolume(string id, double volume)
    {
        GetCoreAudioDevice()[id].Volume = volume * 100f;
    }

    /// <summary>
    /// 获得音量大小
    /// </summary>
    /// <param name="id">设备ID</param>
    /// <returns></returns>
    public static double GetDeviceVolume(string id)
    {
        return GetCoreAudioDevice()[id].Volume;
    }

    /// <summary>
    /// 设置默认设备
    /// 注意此为异步方法，如需当场修改播放设备，请直接对player设置音频播放设备
    /// </summary>
    /// <param name="id">设备ID</param>
    public static void SetDefaultDevice(string id)
    {
        Task.Run(() =>
        {
            using (var enumerator = new CoreAudioController())
            {
                enumerator.SetDefaultDevice(GetCoreAudioDevice()[id]);
            }
        });
    }

    /// <summary>
    /// 获得默认设备ID
    /// </summary>
    /// <returns>设备ID</returns>
    public static string GetDefaultDeviceId()
    {
        using (var enumerator = new CoreAudioController())
        {
            return enumerator.GetDefaultDevice(AudioSwitcher.AudioApi.DeviceType.Playback, AudioSwitcher.AudioApi.Role.Multimedia).RealId;
        }
    }

}