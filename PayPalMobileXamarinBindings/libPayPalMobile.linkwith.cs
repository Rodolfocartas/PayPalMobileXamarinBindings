using System;
using ObjCRuntime;

[assembly: LinkWith ("libPayPalMobile.a",
	LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, 
	SmartLink = true, 
	ForceLoad = true, 
	Frameworks = "AudioToolbox AVFoundation CoreLocation CoreMedia MessageUI MobileCoreServices SystemConfiguration", 
	LinkerFlags="-lz -lxml2 -lc++ -lstdc++"
)]
