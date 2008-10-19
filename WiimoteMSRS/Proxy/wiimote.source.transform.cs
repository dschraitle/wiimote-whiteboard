using System;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.Core.Transforms;

[assembly: ServiceDeclaration(DssServiceDeclaration.Transform, SourceAssemblyKey = @"Wiimote.Y2007.M06, Version=1.1.0.0, Culture=neutral, PublicKeyToken=28ed47d184d2153b")]
[assembly: System.Security.SecurityTransparent]
[assembly: System.Security.AllowPartiallyTrustedCallers]

namespace Dss.Transforms.TransformWiimote
{

    public class Transforms: TransformBase
    {

        public static object Transform_WiimoteLib_Proxy_WiimoteState_WiimoteLib_WiimoteState(object transformObj)
        {
            WiimoteLib.WiimoteState target = new WiimoteLib.WiimoteState();
            WiimoteLib.Proxy.WiimoteState from = transformObj as WiimoteLib.Proxy.WiimoteState;
            target.CalibrationInfo = (WiimoteLib.CalibrationInfo)Transform_WiimoteLib_Proxy_CalibrationInfo_WiimoteLib_CalibrationInfo(from.CalibrationInfo);
            target.ButtonState = (WiimoteLib.ButtonState)Transform_WiimoteLib_Proxy_ButtonState_WiimoteLib_ButtonState(from.ButtonState);
            target.AccelState = (WiimoteLib.AccelState)Transform_WiimoteLib_Proxy_AccelState_WiimoteLib_AccelState(from.AccelState);
            target.IRState = (WiimoteLib.IRState)Transform_WiimoteLib_Proxy_IRState_WiimoteLib_IRState(from.IRState);
            target.Battery = from.Battery;
            target.Rumble = from.Rumble;
            target.Extension = from.Extension;
            target.ExtensionType = (WiimoteLib.ExtensionType)((System.Byte)from.ExtensionType);
            target.NunchukState = (WiimoteLib.NunchukState)Transform_WiimoteLib_Proxy_NunchukState_WiimoteLib_NunchukState(from.NunchukState);
            target.ClassicControllerState = (WiimoteLib.ClassicControllerState)Transform_WiimoteLib_Proxy_ClassicControllerState_WiimoteLib_ClassicControllerState(from.ClassicControllerState);
            target.LEDs = (WiimoteLib.LEDs)Transform_WiimoteLib_Proxy_LEDs_WiimoteLib_LEDs(from.LEDs);
            return target;
        }


        public static object Transform_WiimoteLib_WiimoteState_WiimoteLib_Proxy_WiimoteState(object transformObj)
        {
            WiimoteLib.Proxy.WiimoteState target = new WiimoteLib.Proxy.WiimoteState();
            WiimoteLib.WiimoteState from = transformObj as WiimoteLib.WiimoteState;
            target.CalibrationInfo = (WiimoteLib.Proxy.CalibrationInfo)Transform_WiimoteLib_CalibrationInfo_WiimoteLib_Proxy_CalibrationInfo(from.CalibrationInfo);
            target.ButtonState = (WiimoteLib.Proxy.ButtonState)Transform_WiimoteLib_ButtonState_WiimoteLib_Proxy_ButtonState(from.ButtonState);
            target.AccelState = (WiimoteLib.Proxy.AccelState)Transform_WiimoteLib_AccelState_WiimoteLib_Proxy_AccelState(from.AccelState);
            target.IRState = (WiimoteLib.Proxy.IRState)Transform_WiimoteLib_IRState_WiimoteLib_Proxy_IRState(from.IRState);
            target.Battery = from.Battery;
            target.Rumble = from.Rumble;
            target.Extension = from.Extension;
            target.ExtensionType = (WiimoteLib.Proxy.ExtensionType)((System.Byte)from.ExtensionType);
            target.NunchukState = (WiimoteLib.Proxy.NunchukState)Transform_WiimoteLib_NunchukState_WiimoteLib_Proxy_NunchukState(from.NunchukState);
            target.ClassicControllerState = (WiimoteLib.Proxy.ClassicControllerState)Transform_WiimoteLib_ClassicControllerState_WiimoteLib_Proxy_ClassicControllerState(from.ClassicControllerState);
            target.LEDs = (WiimoteLib.Proxy.LEDs)Transform_WiimoteLib_LEDs_WiimoteLib_Proxy_LEDs(from.LEDs);
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_LEDs_WiimoteLib_LEDs(object transformObj)
        {
            WiimoteLib.LEDs target = new WiimoteLib.LEDs();
            WiimoteLib.Proxy.LEDs from = (WiimoteLib.Proxy.LEDs)transformObj;
            target.LED1 = from.LED1;
            target.LED2 = from.LED2;
            target.LED3 = from.LED3;
            target.LED4 = from.LED4;
            return target;
        }


        public static object Transform_WiimoteLib_LEDs_WiimoteLib_Proxy_LEDs(object transformObj)
        {
            WiimoteLib.Proxy.LEDs target = new WiimoteLib.Proxy.LEDs();
            WiimoteLib.LEDs from = (WiimoteLib.LEDs)transformObj;
            target.LED1 = from.LED1;
            target.LED2 = from.LED2;
            target.LED3 = from.LED3;
            target.LED4 = from.LED4;
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_RumbleRequest_WiimoteLib_RumbleRequest(object transformObj)
        {
            WiimoteLib.RumbleRequest target = new WiimoteLib.RumbleRequest();
            WiimoteLib.Proxy.RumbleRequest from = (WiimoteLib.Proxy.RumbleRequest)transformObj;
            target.Rumble = from.Rumble;
            return target;
        }


        public static object Transform_WiimoteLib_RumbleRequest_WiimoteLib_Proxy_RumbleRequest(object transformObj)
        {
            WiimoteLib.Proxy.RumbleRequest target = new WiimoteLib.Proxy.RumbleRequest();
            WiimoteLib.RumbleRequest from = (WiimoteLib.RumbleRequest)transformObj;
            target.Rumble = from.Rumble;
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_ExtensionType_WiimoteLib_ExtensionType(object transformObj)
        {
            WiimoteLib.ExtensionType target = new WiimoteLib.ExtensionType();
            return target;
        }


        public static object Transform_WiimoteLib_ExtensionType_WiimoteLib_Proxy_ExtensionType(object transformObj)
        {
            WiimoteLib.Proxy.ExtensionType target = new WiimoteLib.Proxy.ExtensionType();
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_CalibrationInfo_WiimoteLib_CalibrationInfo(object transformObj)
        {
            WiimoteLib.CalibrationInfo target = new WiimoteLib.CalibrationInfo();
            WiimoteLib.Proxy.CalibrationInfo from = (WiimoteLib.Proxy.CalibrationInfo)transformObj;
            target.X0 = from.X0;
            target.Y0 = from.Y0;
            target.Z0 = from.Z0;
            target.XG = from.XG;
            target.YG = from.YG;
            target.ZG = from.ZG;
            return target;
        }


        public static object Transform_WiimoteLib_CalibrationInfo_WiimoteLib_Proxy_CalibrationInfo(object transformObj)
        {
            WiimoteLib.Proxy.CalibrationInfo target = new WiimoteLib.Proxy.CalibrationInfo();
            WiimoteLib.CalibrationInfo from = (WiimoteLib.CalibrationInfo)transformObj;
            target.X0 = from.X0;
            target.Y0 = from.Y0;
            target.Z0 = from.Z0;
            target.XG = from.XG;
            target.YG = from.YG;
            target.ZG = from.ZG;
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_ButtonState_WiimoteLib_ButtonState(object transformObj)
        {
            WiimoteLib.ButtonState target = new WiimoteLib.ButtonState();
            WiimoteLib.Proxy.ButtonState from = (WiimoteLib.Proxy.ButtonState)transformObj;
            target.A = from.A;
            target.B = from.B;
            target.Plus = from.Plus;
            target.Home = from.Home;
            target.Minus = from.Minus;
            target.One = from.One;
            target.Two = from.Two;
            target.Up = from.Up;
            target.Down = from.Down;
            target.Left = from.Left;
            target.Right = from.Right;
            return target;
        }


        public static object Transform_WiimoteLib_ButtonState_WiimoteLib_Proxy_ButtonState(object transformObj)
        {
            WiimoteLib.Proxy.ButtonState target = new WiimoteLib.Proxy.ButtonState();
            WiimoteLib.ButtonState from = (WiimoteLib.ButtonState)transformObj;
            target.A = from.A;
            target.B = from.B;
            target.Plus = from.Plus;
            target.Home = from.Home;
            target.Minus = from.Minus;
            target.One = from.One;
            target.Two = from.Two;
            target.Up = from.Up;
            target.Down = from.Down;
            target.Left = from.Left;
            target.Right = from.Right;
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_AccelState_WiimoteLib_AccelState(object transformObj)
        {
            WiimoteLib.AccelState target = new WiimoteLib.AccelState();
            WiimoteLib.Proxy.AccelState from = (WiimoteLib.Proxy.AccelState)transformObj;
            target.RawX = from.RawX;
            target.RawY = from.RawY;
            target.RawZ = from.RawZ;
            target.X = from.X;
            target.Y = from.Y;
            target.Z = from.Z;
            return target;
        }


        public static object Transform_WiimoteLib_AccelState_WiimoteLib_Proxy_AccelState(object transformObj)
        {
            WiimoteLib.Proxy.AccelState target = new WiimoteLib.Proxy.AccelState();
            WiimoteLib.AccelState from = (WiimoteLib.AccelState)transformObj;
            target.RawX = from.RawX;
            target.RawY = from.RawY;
            target.RawZ = from.RawZ;
            target.X = from.X;
            target.Y = from.Y;
            target.Z = from.Z;
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_IRState_WiimoteLib_IRState(object transformObj)
        {
            WiimoteLib.IRState target = new WiimoteLib.IRState();
            WiimoteLib.Proxy.IRState from = (WiimoteLib.Proxy.IRState)transformObj;
            target.Mode = (WiimoteLib.IRMode)((System.Byte)from.Mode);
            target.RawX1 = from.RawX1;
            target.RawX2 = from.RawX2;
            target.RawY1 = from.RawY1;
            target.RawY2 = from.RawY2;
            target.Size1 = from.Size1;
            target.Size2 = from.Size2;
            target.Found1 = from.Found1;
            target.Found2 = from.Found2;
            target.X1 = from.X1;
            target.X2 = from.X2;
            target.Y1 = from.Y1;
            target.Y2 = from.Y2;
            return target;
        }


        public static object Transform_WiimoteLib_IRState_WiimoteLib_Proxy_IRState(object transformObj)
        {
            WiimoteLib.Proxy.IRState target = new WiimoteLib.Proxy.IRState();
            WiimoteLib.IRState from = (WiimoteLib.IRState)transformObj;
            target.Mode = (WiimoteLib.Proxy.IRMode)((System.Byte)from.Mode);
            target.RawX1 = from.RawX1;
            target.RawX2 = from.RawX2;
            target.RawY1 = from.RawY1;
            target.RawY2 = from.RawY2;
            target.Size1 = from.Size1;
            target.Size2 = from.Size2;
            target.Found1 = from.Found1;
            target.Found2 = from.Found2;
            target.X1 = from.X1;
            target.X2 = from.X2;
            target.Y1 = from.Y1;
            target.Y2 = from.Y2;
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_IRMode_WiimoteLib_IRMode(object transformObj)
        {
            WiimoteLib.IRMode target = new WiimoteLib.IRMode();
            return target;
        }


        public static object Transform_WiimoteLib_IRMode_WiimoteLib_Proxy_IRMode(object transformObj)
        {
            WiimoteLib.Proxy.IRMode target = new WiimoteLib.Proxy.IRMode();
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_NunchukState_WiimoteLib_NunchukState(object transformObj)
        {
            WiimoteLib.NunchukState target = new WiimoteLib.NunchukState();
            WiimoteLib.Proxy.NunchukState from = (WiimoteLib.Proxy.NunchukState)transformObj;
            target.CalibrationInfo = (WiimoteLib.NunchukCalibrationInfo)Transform_WiimoteLib_Proxy_NunchukCalibrationInfo_WiimoteLib_NunchukCalibrationInfo(from.CalibrationInfo);
            target.AccelState = (WiimoteLib.AccelState)Transform_WiimoteLib_Proxy_AccelState_WiimoteLib_AccelState(from.AccelState);
            target.RawX = from.RawX;
            target.RawY = from.RawY;
            target.X = from.X;
            target.Y = from.Y;
            target.C = from.C;
            target.Z = from.Z;
            return target;
        }


        public static object Transform_WiimoteLib_NunchukState_WiimoteLib_Proxy_NunchukState(object transformObj)
        {
            WiimoteLib.Proxy.NunchukState target = new WiimoteLib.Proxy.NunchukState();
            WiimoteLib.NunchukState from = (WiimoteLib.NunchukState)transformObj;
            target.CalibrationInfo = (WiimoteLib.Proxy.NunchukCalibrationInfo)Transform_WiimoteLib_NunchukCalibrationInfo_WiimoteLib_Proxy_NunchukCalibrationInfo(from.CalibrationInfo);
            target.AccelState = (WiimoteLib.Proxy.AccelState)Transform_WiimoteLib_AccelState_WiimoteLib_Proxy_AccelState(from.AccelState);
            target.RawX = from.RawX;
            target.RawY = from.RawY;
            target.X = from.X;
            target.Y = from.Y;
            target.C = from.C;
            target.Z = from.Z;
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_NunchukCalibrationInfo_WiimoteLib_NunchukCalibrationInfo(object transformObj)
        {
            WiimoteLib.NunchukCalibrationInfo target = new WiimoteLib.NunchukCalibrationInfo();
            WiimoteLib.Proxy.NunchukCalibrationInfo from = (WiimoteLib.Proxy.NunchukCalibrationInfo)transformObj;
            target.X0 = from.X0;
            target.Y0 = from.Y0;
            target.Z0 = from.Z0;
            target.XG = from.XG;
            target.YG = from.YG;
            target.ZG = from.ZG;
            target.MinX = from.MinX;
            target.MidX = from.MidX;
            target.MaxX = from.MaxX;
            target.MinY = from.MinY;
            target.MidY = from.MidY;
            target.MaxY = from.MaxY;
            return target;
        }


        public static object Transform_WiimoteLib_NunchukCalibrationInfo_WiimoteLib_Proxy_NunchukCalibrationInfo(object transformObj)
        {
            WiimoteLib.Proxy.NunchukCalibrationInfo target = new WiimoteLib.Proxy.NunchukCalibrationInfo();
            WiimoteLib.NunchukCalibrationInfo from = (WiimoteLib.NunchukCalibrationInfo)transformObj;
            target.X0 = from.X0;
            target.Y0 = from.Y0;
            target.Z0 = from.Z0;
            target.XG = from.XG;
            target.YG = from.YG;
            target.ZG = from.ZG;
            target.MinX = from.MinX;
            target.MidX = from.MidX;
            target.MaxX = from.MaxX;
            target.MinY = from.MinY;
            target.MidY = from.MidY;
            target.MaxY = from.MaxY;
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_ClassicControllerState_WiimoteLib_ClassicControllerState(object transformObj)
        {
            WiimoteLib.ClassicControllerState target = new WiimoteLib.ClassicControllerState();
            WiimoteLib.Proxy.ClassicControllerState from = (WiimoteLib.Proxy.ClassicControllerState)transformObj;
            target.CalibrationInfo = (WiimoteLib.ClassicControllerCalibrationInfo)Transform_WiimoteLib_Proxy_ClassicControllerCalibrationInfo_WiimoteLib_ClassicControllerCalibrationInfo(from.CalibrationInfo);
            target.ButtonState = (WiimoteLib.ClassicControllerButtonState)Transform_WiimoteLib_Proxy_ClassicControllerButtonState_WiimoteLib_ClassicControllerButtonState(from.ButtonState);
            target.RawXL = from.RawXL;
            target.RawYL = from.RawYL;
            target.RawXR = from.RawXR;
            target.RawYR = from.RawYR;
            target.XL = from.XL;
            target.YL = from.YL;
            target.XR = from.XR;
            target.YR = from.YR;
            target.RawTriggerL = from.RawTriggerL;
            target.RawTriggerR = from.RawTriggerR;
            target.TriggerL = from.TriggerL;
            target.TriggerR = from.TriggerR;
            return target;
        }


        public static object Transform_WiimoteLib_ClassicControllerState_WiimoteLib_Proxy_ClassicControllerState(object transformObj)
        {
            WiimoteLib.Proxy.ClassicControllerState target = new WiimoteLib.Proxy.ClassicControllerState();
            WiimoteLib.ClassicControllerState from = (WiimoteLib.ClassicControllerState)transformObj;
            target.CalibrationInfo = (WiimoteLib.Proxy.ClassicControllerCalibrationInfo)Transform_WiimoteLib_ClassicControllerCalibrationInfo_WiimoteLib_Proxy_ClassicControllerCalibrationInfo(from.CalibrationInfo);
            target.ButtonState = (WiimoteLib.Proxy.ClassicControllerButtonState)Transform_WiimoteLib_ClassicControllerButtonState_WiimoteLib_Proxy_ClassicControllerButtonState(from.ButtonState);
            target.RawXL = from.RawXL;
            target.RawYL = from.RawYL;
            target.RawXR = from.RawXR;
            target.RawYR = from.RawYR;
            target.XL = from.XL;
            target.YL = from.YL;
            target.XR = from.XR;
            target.YR = from.YR;
            target.RawTriggerL = from.RawTriggerL;
            target.RawTriggerR = from.RawTriggerR;
            target.TriggerL = from.TriggerL;
            target.TriggerR = from.TriggerR;
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_ClassicControllerCalibrationInfo_WiimoteLib_ClassicControllerCalibrationInfo(object transformObj)
        {
            WiimoteLib.ClassicControllerCalibrationInfo target = new WiimoteLib.ClassicControllerCalibrationInfo();
            WiimoteLib.Proxy.ClassicControllerCalibrationInfo from = (WiimoteLib.Proxy.ClassicControllerCalibrationInfo)transformObj;
            target.MinXL = from.MinXL;
            target.MidXL = from.MidXL;
            target.MaxXL = from.MaxXL;
            target.MinYL = from.MinYL;
            target.MidYL = from.MidYL;
            target.MaxYL = from.MaxYL;
            target.MinXR = from.MinXR;
            target.MidXR = from.MidXR;
            target.MaxXR = from.MaxXR;
            target.MinYR = from.MinYR;
            target.MidYR = from.MidYR;
            target.MaxYR = from.MaxYR;
            target.MinTriggerL = from.MinTriggerL;
            target.MaxTriggerL = from.MaxTriggerL;
            target.MinTriggerR = from.MinTriggerR;
            target.MaxTriggerR = from.MaxTriggerR;
            return target;
        }


        public static object Transform_WiimoteLib_ClassicControllerCalibrationInfo_WiimoteLib_Proxy_ClassicControllerCalibrationInfo(object transformObj)
        {
            WiimoteLib.Proxy.ClassicControllerCalibrationInfo target = new WiimoteLib.Proxy.ClassicControllerCalibrationInfo();
            WiimoteLib.ClassicControllerCalibrationInfo from = (WiimoteLib.ClassicControllerCalibrationInfo)transformObj;
            target.MinXL = from.MinXL;
            target.MidXL = from.MidXL;
            target.MaxXL = from.MaxXL;
            target.MinYL = from.MinYL;
            target.MidYL = from.MidYL;
            target.MaxYL = from.MaxYL;
            target.MinXR = from.MinXR;
            target.MidXR = from.MidXR;
            target.MaxXR = from.MaxXR;
            target.MinYR = from.MinYR;
            target.MidYR = from.MidYR;
            target.MaxYR = from.MaxYR;
            target.MinTriggerL = from.MinTriggerL;
            target.MaxTriggerL = from.MaxTriggerL;
            target.MinTriggerR = from.MinTriggerR;
            target.MaxTriggerR = from.MaxTriggerR;
            return target;
        }


        public static object Transform_WiimoteLib_Proxy_ClassicControllerButtonState_WiimoteLib_ClassicControllerButtonState(object transformObj)
        {
            WiimoteLib.ClassicControllerButtonState target = new WiimoteLib.ClassicControllerButtonState();
            WiimoteLib.Proxy.ClassicControllerButtonState from = (WiimoteLib.Proxy.ClassicControllerButtonState)transformObj;
            target.A = from.A;
            target.B = from.B;
            target.Plus = from.Plus;
            target.Home = from.Home;
            target.Minus = from.Minus;
            target.Up = from.Up;
            target.Down = from.Down;
            target.Left = from.Left;
            target.Right = from.Right;
            target.X = from.X;
            target.Y = from.Y;
            target.ZL = from.ZL;
            target.ZR = from.ZR;
            target.TriggerL = from.TriggerL;
            target.TriggerR = from.TriggerR;
            return target;
        }


        public static object Transform_WiimoteLib_ClassicControllerButtonState_WiimoteLib_Proxy_ClassicControllerButtonState(object transformObj)
        {
            WiimoteLib.Proxy.ClassicControllerButtonState target = new WiimoteLib.Proxy.ClassicControllerButtonState();
            WiimoteLib.ClassicControllerButtonState from = (WiimoteLib.ClassicControllerButtonState)transformObj;
            target.A = from.A;
            target.B = from.B;
            target.Plus = from.Plus;
            target.Home = from.Home;
            target.Minus = from.Minus;
            target.Up = from.Up;
            target.Down = from.Down;
            target.Left = from.Left;
            target.Right = from.Right;
            target.X = from.X;
            target.Y = from.Y;
            target.ZL = from.ZL;
            target.ZR = from.ZR;
            target.TriggerL = from.TriggerL;
            target.TriggerR = from.TriggerR;
            return target;
        }

        static Transforms()
        {
            AddProxyTransform(typeof(WiimoteLib.Proxy.WiimoteState), Transform_WiimoteLib_Proxy_WiimoteState_WiimoteLib_WiimoteState);
            AddSourceTransform(typeof(WiimoteLib.WiimoteState), Transform_WiimoteLib_WiimoteState_WiimoteLib_Proxy_WiimoteState);
            AddProxyTransform(typeof(WiimoteLib.Proxy.LEDs), Transform_WiimoteLib_Proxy_LEDs_WiimoteLib_LEDs);
            AddSourceTransform(typeof(WiimoteLib.LEDs), Transform_WiimoteLib_LEDs_WiimoteLib_Proxy_LEDs);
            AddProxyTransform(typeof(WiimoteLib.Proxy.RumbleRequest), Transform_WiimoteLib_Proxy_RumbleRequest_WiimoteLib_RumbleRequest);
            AddSourceTransform(typeof(WiimoteLib.RumbleRequest), Transform_WiimoteLib_RumbleRequest_WiimoteLib_Proxy_RumbleRequest);
            AddProxyTransform(typeof(WiimoteLib.Proxy.ExtensionType), Transform_WiimoteLib_Proxy_ExtensionType_WiimoteLib_ExtensionType);
            AddSourceTransform(typeof(WiimoteLib.ExtensionType), Transform_WiimoteLib_ExtensionType_WiimoteLib_Proxy_ExtensionType);
            AddProxyTransform(typeof(WiimoteLib.Proxy.CalibrationInfo), Transform_WiimoteLib_Proxy_CalibrationInfo_WiimoteLib_CalibrationInfo);
            AddSourceTransform(typeof(WiimoteLib.CalibrationInfo), Transform_WiimoteLib_CalibrationInfo_WiimoteLib_Proxy_CalibrationInfo);
            AddProxyTransform(typeof(WiimoteLib.Proxy.ButtonState), Transform_WiimoteLib_Proxy_ButtonState_WiimoteLib_ButtonState);
            AddSourceTransform(typeof(WiimoteLib.ButtonState), Transform_WiimoteLib_ButtonState_WiimoteLib_Proxy_ButtonState);
            AddProxyTransform(typeof(WiimoteLib.Proxy.AccelState), Transform_WiimoteLib_Proxy_AccelState_WiimoteLib_AccelState);
            AddSourceTransform(typeof(WiimoteLib.AccelState), Transform_WiimoteLib_AccelState_WiimoteLib_Proxy_AccelState);
            AddProxyTransform(typeof(WiimoteLib.Proxy.IRState), Transform_WiimoteLib_Proxy_IRState_WiimoteLib_IRState);
            AddSourceTransform(typeof(WiimoteLib.IRState), Transform_WiimoteLib_IRState_WiimoteLib_Proxy_IRState);
            AddProxyTransform(typeof(WiimoteLib.Proxy.IRMode), Transform_WiimoteLib_Proxy_IRMode_WiimoteLib_IRMode);
            AddSourceTransform(typeof(WiimoteLib.IRMode), Transform_WiimoteLib_IRMode_WiimoteLib_Proxy_IRMode);
            AddProxyTransform(typeof(WiimoteLib.Proxy.NunchukState), Transform_WiimoteLib_Proxy_NunchukState_WiimoteLib_NunchukState);
            AddSourceTransform(typeof(WiimoteLib.NunchukState), Transform_WiimoteLib_NunchukState_WiimoteLib_Proxy_NunchukState);
            AddProxyTransform(typeof(WiimoteLib.Proxy.NunchukCalibrationInfo), Transform_WiimoteLib_Proxy_NunchukCalibrationInfo_WiimoteLib_NunchukCalibrationInfo);
            AddSourceTransform(typeof(WiimoteLib.NunchukCalibrationInfo), Transform_WiimoteLib_NunchukCalibrationInfo_WiimoteLib_Proxy_NunchukCalibrationInfo);
            AddProxyTransform(typeof(WiimoteLib.Proxy.ClassicControllerState), Transform_WiimoteLib_Proxy_ClassicControllerState_WiimoteLib_ClassicControllerState);
            AddSourceTransform(typeof(WiimoteLib.ClassicControllerState), Transform_WiimoteLib_ClassicControllerState_WiimoteLib_Proxy_ClassicControllerState);
            AddProxyTransform(typeof(WiimoteLib.Proxy.ClassicControllerCalibrationInfo), Transform_WiimoteLib_Proxy_ClassicControllerCalibrationInfo_WiimoteLib_ClassicControllerCalibrationInfo);
            AddSourceTransform(typeof(WiimoteLib.ClassicControllerCalibrationInfo), Transform_WiimoteLib_ClassicControllerCalibrationInfo_WiimoteLib_Proxy_ClassicControllerCalibrationInfo);
            AddProxyTransform(typeof(WiimoteLib.Proxy.ClassicControllerButtonState), Transform_WiimoteLib_Proxy_ClassicControllerButtonState_WiimoteLib_ClassicControllerButtonState);
            AddSourceTransform(typeof(WiimoteLib.ClassicControllerButtonState), Transform_WiimoteLib_ClassicControllerButtonState_WiimoteLib_Proxy_ClassicControllerButtonState);
        }
    }
}

