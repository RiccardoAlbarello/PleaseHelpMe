void GetMainLight_float(in float3 WorldPos, out float3 MainLightDirection, out float3 MainLightColor, out float MainLightShadowAttenuation) {
    #if SHADERGRAPH_PREVIEW
        MainLightDirection = float3(0.5,0.5,0.0);
        MainLightColor = float3(0.5,0.5,0);
        MainLightShadowAttenuation = 1.0;

    # else
        float4 ShadowCoordinates = TransformWorldToShadowCoord(WorldPos);
        Light MainLight = GetMainLight(ShadowCoordinates);

        MainLightDirection = MainLight.direction;
        MainLightColor = MainLight.color;
        MainLightShadowAttenuation = MainLight.shadowAttenuation;
    #endif
}