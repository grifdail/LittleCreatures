// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33525,y:32690,varname:node_3138,prsc:2|emission-4125-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32567,y:33359,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Color,id:4740,x:32746,y:33129,ptovrint:False,ptlb:Color_copy,ptin:_Color_copy,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6985294,c2:0.6985294,c3:0.6985294,c4:1;n:type:ShaderForge.SFN_Lerp,id:8599,x:33003,y:33234,varname:node_8599,prsc:2|A-4740-RGB,B-7241-RGB,T-9034-OUT;n:type:ShaderForge.SFN_Vector1,id:413,x:32320,y:33556,varname:node_413,prsc:2,v1:2;n:type:ShaderForge.SFN_Fresnel,id:9034,x:32546,y:33570,varname:node_9034,prsc:2|EXP-413-OUT;n:type:ShaderForge.SFN_Vector1,id:8163,x:32837,y:33636,varname:node_8163,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:1160,x:33021,y:33495,varname:node_1160,prsc:2|A-9677-RGB,B-8163-OUT;n:type:ShaderForge.SFN_Cubemap,id:9677,x:32837,y:33466,ptovrint:False,ptlb:ttt,ptin:_ttt,varname:node_9677,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,pvfc:0;n:type:ShaderForge.SFN_Blend,id:7426,x:33210,y:33100,varname:node_7426,prsc:2,blmd:5,clmp:True|SRC-1160-OUT,DST-8599-OUT;n:type:ShaderForge.SFN_Tex2d,id:3520,x:32533,y:32534,ptovrint:False,ptlb:screen,ptin:_screen,varname:node_3520,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aee47dacb114d44458c3c6d69252c95f,ntxv:0,isnm:False|UVIN-7309-UVOUT;n:type:ShaderForge.SFN_Panner,id:7309,x:32377,y:32469,varname:node_7309,prsc:2,spu:0.5,spv:0.5|UVIN-3942-UVOUT,DIST-5754-OUT;n:type:ShaderForge.SFN_TexCoord,id:3942,x:32119,y:32506,varname:node_3942,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:902,x:31182,y:32580,ptovrint:False,ptlb:d,ptin:_d,varname:node_902,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8376068,max:1;n:type:ShaderForge.SFN_Time,id:5426,x:31131,y:32360,varname:node_5426,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:8827,x:31519,y:32523,varname:node_8827,prsc:2,frmn:0,frmx:1,tomn:1,tomx:10|IN-902-OUT;n:type:ShaderForge.SFN_Divide,id:5754,x:31668,y:32484,varname:node_5754,prsc:2|A-1946-OUT,B-8827-OUT;n:type:ShaderForge.SFN_Sin,id:1946,x:31400,y:32368,varname:node_1946,prsc:2|IN-5426-T;n:type:ShaderForge.SFN_FragmentPosition,id:5789,x:31940,y:32109,varname:node_5789,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:2485,x:32237,y:32019,varname:node_2485,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5789-X;n:type:ShaderForge.SFN_Append,id:2294,x:32935,y:32527,varname:node_2294,prsc:2|A-6872-OUT,B-9405-OUT;n:type:ShaderForge.SFN_ComponentMask,id:7068,x:32237,y:32168,varname:node_7068,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5789-Y;n:type:ShaderForge.SFN_Multiply,id:6872,x:32598,y:32190,varname:node_6872,prsc:2|A-2485-OUT,B-7068-OUT,C-7844-OUT;n:type:ShaderForge.SFN_ComponentMask,id:7844,x:32237,y:32318,varname:node_7844,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5789-Z;n:type:ShaderForge.SFN_Color,id:602,x:32813,y:32224,ptovrint:False,ptlb:node_602,ptin:_node_602,varname:node_602,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2412414,c2:0.2459238,c3:0.3382353,c4:1;n:type:ShaderForge.SFN_Multiply,id:4125,x:33138,y:32472,varname:node_4125,prsc:2|A-602-RGB,B-2294-OUT;n:type:ShaderForge.SFN_Tex2d,id:120,x:32322,y:32747,ptovrint:False,ptlb:node_120,ptin:_node_120,varname:node_120,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-2244-UVOUT;n:type:ShaderForge.SFN_Multiply,id:9405,x:32935,y:32683,varname:node_9405,prsc:2|A-3520-RGB,B-1245-OUT;n:type:ShaderForge.SFN_Slider,id:5698,x:32213,y:32996,ptovrint:False,ptlb:node_5698,ptin:_node_5698,varname:node_5698,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:2;n:type:ShaderForge.SFN_Add,id:1245,x:32786,y:32883,varname:node_1245,prsc:2|A-120-RGB,B-5698-OUT;n:type:ShaderForge.SFN_Panner,id:2244,x:32167,y:32747,varname:node_2244,prsc:2,spu:2,spv:2|UVIN-3942-UVOUT,DIST-2656-OUT;n:type:ShaderForge.SFN_Vector1,id:4128,x:31209,y:33055,varname:node_4128,prsc:2,v1:40;n:type:ShaderForge.SFN_Divide,id:2656,x:31724,y:32911,varname:node_2656,prsc:2|A-5426-TDB,B-4128-OUT;proporder:7241-4740-9677-3520-902-602-120-5698;pass:END;sub:END;*/

Shader "Shader Forge/Vitre" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Color_copy ("Color_copy", Color) = (0.6985294,0.6985294,0.6985294,1)
        _ttt ("ttt", Cube) = "_Skybox" {}
        _screen ("screen", 2D) = "white" {}
        _d ("d", Range(0, 1)) = 0.8376068
        _node_602 ("node_602", Color) = (0.2412414,0.2459238,0.3382353,1)
        _node_120 ("node_120", 2D) = "white" {}
        _node_5698 ("node_5698", Range(1, 2)) = 1
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _screen; uniform float4 _screen_ST;
            uniform float _d;
            uniform float4 _node_602;
            uniform sampler2D _node_120; uniform float4 _node_120_ST;
            uniform float _node_5698;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_5426 = _Time + _TimeEditor;
                float2 node_7309 = (i.uv0+(sin(node_5426.g)/(_d*9.0+1.0))*float2(0.5,0.5));
                float4 _screen_var = tex2D(_screen,TRANSFORM_TEX(node_7309, _screen));
                float2 node_2244 = (i.uv0+(node_5426.b/40.0)*float2(2,2));
                float4 _node_120_var = tex2D(_node_120,TRANSFORM_TEX(node_2244, _node_120));
                float3 emissive = (_node_602.rgb*float4((i.posWorld.r.r*i.posWorld.g.r*i.posWorld.b.r),(_screen_var.rgb*(_node_120_var.rgb+_node_5698))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
