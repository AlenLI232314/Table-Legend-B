#if UNITY_WSA && ! UNITY_EDITOR
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public enum AkAudioAPI {
  AkAPI_Wasapi = 1 << 0,
  AkAPI_XAudio2 = 1 << 1,
  AkAPI_DirectSound = 1 << 2,
  AkAPI_Default = AkAPI_Wasapi|AkAPI_XAudio2|AkAPI_DirectSound
}
#endif // #if UNITY_WSA && ! UNITY_EDITOR