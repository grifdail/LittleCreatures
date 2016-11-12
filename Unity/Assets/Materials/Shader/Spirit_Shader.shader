// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:6,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33525,y:32690,varname:node_3138,prsc:2|emission-7426-OUT,voffset-6131-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32094,y:32189,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Time,id:7646,x:32057,y:33300,varname:node_7646,prsc:2;n:type:ShaderForge.SFN_Sin,id:6215,x:32614,y:33157,varname:node_6215,prsc:2|IN-7646-TDB;n:type:ShaderForge.SFN_Cos,id:9393,x:32491,y:33292,varname:node_9393,prsc:2|IN-7646-TTR;n:type:ShaderForge.SFN_Multiply,id:6131,x:32962,y:33253,varname:node_6131,prsc:2|A-4622-OUT,B-4733-OUT,C-2112-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:9848,x:31455,y:33197,varname:node_9848,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:3704,x:32312,y:33007,varname:node_3704,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-1144-OUT;n:type:ShaderForge.SFN_Multiply,id:4622,x:32893,y:33075,varname:node_4622,prsc:2|A-6215-OUT,B-3704-OUT;n:type:ShaderForge.SFN_ComponentMask,id:3139,x:32206,y:33475,varname:node_3139,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-2155-OUT;n:type:ShaderForge.SFN_Multiply,id:4733,x:32722,y:33379,varname:node_4733,prsc:2|A-9393-OUT,B-3139-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1211,x:32416,y:33723,varname:node_1211,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-9438-OUT;n:type:ShaderForge.SFN_Multiply,id:2112,x:32826,y:33672,varname:node_2112,prsc:2|A-4294-OUT,B-1211-OUT;n:type:ShaderForge.SFN_Color,id:4740,x:32123,y:32417,ptovrint:False,ptlb:Color_copy,ptin:_Color_copy,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6985294,c2:0.6985294,c3:0.6985294,c4:1;n:type:ShaderForge.SFN_Lerp,id:8599,x:32565,y:32564,varname:node_8599,prsc:2|A-4740-RGB,B-7241-RGB,T-9034-OUT;n:type:ShaderForge.SFN_Vector1,id:413,x:31926,y:32724,varname:node_413,prsc:2,v1:2;n:type:ShaderForge.SFN_Fresnel,id:9034,x:32175,y:32737,varname:node_9034,prsc:2|EXP-413-OUT;n:type:ShaderForge.SFN_Vector1,id:8163,x:32470,y:32398,varname:node_8163,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:1160,x:32654,y:32257,varname:node_1160,prsc:2|A-9677-RGB,B-8163-OUT;n:type:ShaderForge.SFN_Cubemap,id:9677,x:32470,y:32228,ptovrint:False,ptlb:node_9677,ptin:_node_9677,varname:node_9677,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,pvfc:0;n:type:ShaderForge.SFN_Blend,id:7426,x:32806,y:32584,varname:node_7426,prsc:2,blmd:5,clmp:True|SRC-1160-OUT,DST-8599-OUT;n:type:ShaderForge.SFN_Vector1,id:7871,x:33157,y:33503,varname:node_7871,prsc:2,v1:-10;n:type:ShaderForge.SFN_Vector1,id:6229,x:33157,y:33586,varname:node_6229,prsc:2,v1:0;n:type:ShaderForge.SFN_Sin,id:4294,x:32599,y:33558,varname:node_4294,prsc:2|IN-7646-T;n:type:ShaderForge.SFN_ObjectPosition,id:4728,x:31533,y:33053,varname:node_4728,prsc:2;n:type:ShaderForge.SFN_Subtract,id:1774,x:31909,y:33019,varname:node_1774,prsc:2|A-9848-X,B-4728-X;n:type:ShaderForge.SFN_Subtract,id:3093,x:31849,y:33453,varname:node_3093,prsc:2|A-9848-Y,B-4728-Y;n:type:ShaderForge.SFN_Subtract,id:5197,x:31761,y:33623,varname:node_5197,prsc:2|A-9848-Z,B-4728-Z;n:type:ShaderForge.SFN_Multiply,id:1144,x:32106,y:33078,varname:node_1144,prsc:2|A-1774-OUT,B-1578-OUT;n:type:ShaderForge.SFN_Slider,id:133,x:31060,y:33582,ptovrint:False,ptlb:node_133,ptin:_node_133,varname:node_133,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:2155,x:32045,y:33504,varname:node_2155,prsc:2|A-3093-OUT,B-1578-OUT;n:type:ShaderForge.SFN_Multiply,id:9438,x:32100,y:33681,varname:node_9438,prsc:2|A-5197-OUT,B-1578-OUT;n:type:ShaderForge.SFN_RemapRange,id:1578,x:31431,y:33578,varname:node_1578,prsc:2,frmn:1,frmx:10,tomn:1,tomx:1.5|IN-133-OUT;proporder:7241-4740-9677-133;pass:END;sub:END;*/

Shader "Shader Forge/Spirit_Shader" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Color_copy ("Color_copy", Color) = (0.6985294,0.6985294,0.6985294,1)
        _node_9677 ("node_9677", Cube) = "_Skybox" {}
        _node_133 ("node_133", Range(1, 10)) = 1
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
            Blend One OneMinusSrcColor
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
            uniform float4 _Color;
            uniform float4 _Color_copy;
            uniform samplerCUBE _node_9677;
            uniform float _node_133;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float4 node_7646 = _Time + _TimeEditor;
                float node_1578 = (_node_133*0.05555556+0.9444444);
                float node_6131 = ((sin(node_7646.b)*((mul(unity_ObjectToWorld, v.vertex).r-objPos.r)*node_1578).r)*(cos(node_7646.a)*((mul(unity_ObjectToWorld, v.vertex).g-objPos.g)*node_1578).r)*(sin(node_7646.g)*((mul(unity_ObjectToWorld, v.vertex).b-objPos.b)*node_1578).r));
                v.vertex.xyz += float3(node_6131,node_6131,node_6131);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float3 node_7426 = saturate(max((texCUBE(_node_9677,viewReflectDirection).rgb*0.0),lerp(_Color_copy.rgb,_Color.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),2.0))));
                float3 emissive = node_7426;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _node_133;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float4 node_7646 = _Time + _TimeEditor;
                float node_1578 = (_node_133*0.05555556+0.9444444);
                float node_6131 = ((sin(node_7646.b)*((mul(unity_ObjectToWorld, v.vertex).r-objPos.r)*node_1578).r)*(cos(node_7646.a)*((mul(unity_ObjectToWorld, v.vertex).g-objPos.g)*node_1578).r)*(sin(node_7646.g)*((mul(unity_ObjectToWorld, v.vertex).b-objPos.b)*node_1578).r));
                v.vertex.xyz += float3(node_6131,node_6131,node_6131);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
