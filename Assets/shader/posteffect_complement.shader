Shader "Custom/posteffect_complement"
{
	SubShader
	{
		ZWrite Off

		GrabPass
		{
			"_BackgroundTexture"
		}

		Pass
		{
			Tags
			{
				"RenderType" = "Transparent"
				"Queue" = "Transparent+1"
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct v2f
			{
				float4 grabPos : TEXCOORD0;
				float4 pos : SV_POSITION;
			};

			v2f vert (appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.grabPos = ComputeGrabScreenPos(o.pos);
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _BackgroundTexture;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 color = tex2Dproj(_BackgroundTexture, i.grabPos);
				// just invert the colors
				return 1 - color;
			}
			ENDCG
		}
	}
}
