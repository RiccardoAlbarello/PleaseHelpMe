void HalfLambert_float(in float3 Normal, in float3 WorldPos, in float3 Ambient, out float3 MainLightDirection, out float3 RampOutput) {
    // set the shader graph node previews
    #ifdef SHADERGRAPH_PREVIEW
        RampOutput = float3(0.5,0.5,0);
        MainLightDirection = float3(0.5,0.5,0);
    #else

        float4 shadowCoord = TransformWorldToShadowCoord(WorldPos);
        Light light = GetMainLight(shadowCoord);
 
        // dot product

        // half dot_p_main = sqrt( dot(Normal, light.direction) * 0.5 + 0.5);
                half dot_p_main = dot(Normal, light.direction) * 0.5 + 0.5;
 
        float3 extraLights;
        // get the number of point/spot lights
        int pixelLightCount = GetAdditionalLightsCount();
        // loop over every light
        for (int j = 0; j < pixelLightCount; ++j) {
            // grab the point light
            // If you get an error here V remove the ", half4(1,1,1,1)" part
            Light aLight = GetAdditionalLight(j, WorldPos, half4(1, 1, 1, 1));
            
            // grab the light, shadows ,and light color
            float3 attenuatedLightColor = aLight.color * (aLight.distanceAttenuation * aLight.shadowAttenuation);
            
            // dot product for toonramp
            // half d = sqrt( dot(Normal, aLight.direction)* 0.5 + 0.5);
            half d = dot(Normal, aLight.direction)* 0.5 + 0.5;
 
            // add them all together
            extraLights += (attenuatedLightColor * d);
        }
        
        // multiply with shadows;
        dot_p_main *= light.shadowAttenuation;
 
        // add in lights and extra tinting
        RampOutput = light.color * dot_p_main  + Ambient;
 
        // also add in point/spot lights
        RampOutput += extraLights;
        // output direction for rimlight
        
        // #if MAIN_LIGHT
        MainLightDirection = normalize(light.direction);
        // #else
        // if no main light, use a side down angle
            // Direction = float3(0.5,0.8,0);
        // #endif
 
    #endif
}