using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using XLua;

public class BLibBufferCom
{
    private IntPtr _bufPtr;

    private LuaEnv _luaEnv;

    public BLibBufferCom()
    {
        _luaEnv = EIComponent.Get<GameLuaCom>().LuaEnv;

        BLib_DLL.InitCLog();

        BLib_DLL.luaopen_blib(_luaEnv.L);
    }

    public void New(int buf_id, int initSize)
    {
        if(_bufPtr == IntPtr.Zero)
        {
            BLib_DLL.blib_new(_luaEnv.L, initSize, buf_id);

            _bufPtr = BLib_DLL.blib_get_channel(_luaEnv.L, buf_id);
        }
    }

    public void Close(int buf_id)
    {
        BLib_DLL.blib_free(_luaEnv.L, buf_id);

        //_luaEnv = null;

        //_bufPtr = IntPtr.Zero;
    }

    public void Reset(int buf_id)
    {
        BLib_DLL.blib_reset(_luaEnv.L, buf_id);
    }

    public void SetChannel(int buf_id)
    {
        BLib_DLL.blib_set_channel(_luaEnv.L, _bufPtr, buf_id);
    }

    public IntPtr GetChannel(int buf_id)
    {
        return BLib_DLL.blib_get_channel(_luaEnv.L, buf_id);
    }

    public void WriteInt(int value)
	{
        if (_bufPtr == IntPtr.Zero)
        {
            UnityEngine.Debug.LogError("WtireInt _bufPtr is null");
            return;
        }

        BLib_DLL.blib_write_int(_bufPtr, value);
    }

    public void WriteString(string value)
    {
        if (_bufPtr == IntPtr.Zero)
        {
            UnityEngine.Debug.LogError("WtireString _bufPtr is null");
            return;
        }

        BLib_DLL.blib_write_string(_bufPtr, value);
    }

    public void WriteShort(short value)
    {
        if (_bufPtr == IntPtr.Zero)
        {
            UnityEngine.Debug.LogError("WtireShort _bufPtr is null");
            return;
        }

        BLib_DLL.blib_write_short(_bufPtr, value);
    }

    public void WriteDouble(double value)
    {
        if (_bufPtr == IntPtr.Zero)
        {
            UnityEngine.Debug.LogError("WtireDouble _bufPtr is null");
            return;
        }

        BLib_DLL.blib_write_double(_bufPtr, value);
    }

    public int ReadInt()
    {
        return BLib_DLL.blib_read_int(_bufPtr);
    }

	public string ReadString()
    {
        return Marshal.PtrToStringAnsi(BLib_DLL.blib_read_string(_bufPtr));
    }

	public short ReadShort()
    {
        return BLib_DLL.blib_read_short(_bufPtr);
    }

    public double ReadDouble()
    {
        return BLib_DLL.blib_read_double(_bufPtr);
    }
}
