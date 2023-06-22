Shader "Custom/PyramidFaces"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PyramidHeight ("Pyramid Height", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline" = "UniversalPipeline" }
        LOD 100

        // Forward Lit Pass
        Pass
        {

            Name "ForwardLit"
            Tags {"LightMode" = "UniversalForward"}
            Cull Back

            HLSLPROGRAM

            //Signal this shader requires geometry programs (?)
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 2.0
            #pragma require geometry

            // Lighting and Shadow Keywords
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _ADDITIONAL_LIGHTS
            #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile _ _SHADOWS_SOFT

            // Register Vertex and Fragment functions
            #pragma vertex Vertex
            #pragma geometry Geometry
            #pragma fragment Fragment

            #include "PyramidFaces.hlsl"

            ENDHLSL





        }
    }
}
