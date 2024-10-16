Shader "Custom/NewShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)  // Float4 을 받는 인터페이스
        //_Name ("Float4", Color) (1,1,1,1)
        // _Name ("Vector", Vector) (1,1,1,1)
        _Color2 ("Sub",Color) = (0,0,0,0)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        // 기타 Sampler를 받는 인터페이스
        //_Name3 ("이름", 2D) = "name" {options}
        //              Rect, Cube, 3D
        _Glossiness ("Smoothness", Range(0,1)) = 0.5    // float 을 받는인터페이스
        //_Name ("인스펙터에서 보여질 이름", Range(최소, 최대값)) = 초기값
        //_Name ("인스펙터에서 보여질 이름", 단일값(float,int)) = 값
//        _Test ("Test", float4) = float4(1,0,1,0)
        _Name2 ("Test",float) = 0.1
        _Test2 ("TT",Color) = (1,1,1,1)
        _Metallic ("Metallic", Range(0,1)) = 0.0        // float 을 받는인터페이스

        //RGB값 분리해 적용시키기
        _Red ("Red",Range(0,1)) = 0.0
        _Green ("Green",Range(0,1)) = 0.0
        _Blue ("Blue",Range(0,1)) = 0.0
        _Alpha ("Alpha",Range(0,1))=1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        cull off

        // 전처리라고 할수 있음, 스니핏 이라고도 부름
        // 셰이더의 조명 계산 설정, 기타 세부적인 분기를 정해주는 부분
        CGPROGRAM
        
        //#pragma surface surf Standard fullforwardshadow;
        #pragma surface surf Standard alpha:fade

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed4 _Test2;
        float _Red;
        float _Green;
        float _Blue;
        float _Alpha;


        // 연산되는 코드 부분
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            //o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            //float4 test =float4(1,1,0,1);
            o.Emission = _Test2.rgb;
            o.Albedo = float3(_Red,_Green,_Blue);
            o.Smoothness = _Glossiness;
            o.Alpha = _Alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
