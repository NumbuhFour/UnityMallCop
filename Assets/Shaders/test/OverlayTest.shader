Shader "Tests/Solid" {
    Properties {
    	_Color ("Color", Color) = (1.0, 0.0, 0.0, 1.0)
     	_Amount ("Selection Outline Amount", Range(.002, 0.8)) = .08
     	_SelOutlineColor ("Selection Outline Color", Color) = (0.25,1.0,0.25,1.0)
     	//_ScrollSpeed ("Scroll Speed", Range(-2,2)) = -0.8
        // other properties like colors or vectors go here as well
    }
    SubShader {
	    Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
	   	//Tags { "RenderType" = "Opaue" }
        // here goes the 'meat' of your
        // - surface shader or
        // - vertex and fragment shader or
        // - fixed function shader
        ZWrite Off
		Pass {
        	Name "Hightlight"
        	Cull Front
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
        	float4 _Color;
			float _Amount;
        	float4 _SelOutlineColor;
        	struct vertexInput {
        		float4 normal: NORMAL;
        		float4 vertex : POSITION;
        		float4 color : COLOR;
        	};
        	
        	struct vertexOutput {
        		float4 pos : SV_POSITION;
        		float4 color : COLOR;
        	};
        	
        	vertexOutput vert(vertexInput v){
        		vertexOutput o;
				v.vertex.xyz += v.normal * 0.1;
        		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
        		o.color = _SelOutlineColor;
        		return o;
        	}
        	
        	float4 frag(vertexOutput i) : COLOR
        	{
        		return  float4(0.25,1.0,0.25,0.01);
        	}
			ENDCG
		}
	    Blend SrcAlpha OneMinusSrcAlpha
        Pass {
        	Name "CCTV"
        	CGPROGRAM
        	#pragma vertex vert
        	#pragma fragment frag
        	float4 _Color;
			float _Amount;
        	float4 _SelOutlineColor;
        	float _Timer;
        	float _ScrollSpeed = -0.8;
        	struct vertexInput {
        		float4 normal: NORMAL;
        		float4 vertex : POSITION;
        		float4 color : COLOR;
        	};
        	
        	struct vertexOutput {
        		float4 pos : SV_POSITION;
        		float4 color : COLOR;
        	};
        	
        	vertexOutput vert(vertexInput v){
        		vertexOutput o;
				//v.vertex.xyz += v.normal * 0.8;
        		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
        		o.color = o.pos;//float4(o.pos[1],0.0,0.0,1.0);
        		return o;
        	}
        	
        	float4 frag(vertexOutput i) : COLOR
        	{
        		float4 temp = float4(0.1,1.0,0.2,0.4);
        		temp[1] = sin(i.pos[1]*7.0+_Timer*-0.2)/2.0+0.5;
        		return temp;//float4(1.0,0.0,0.0,1.0);
        	}
        	ENDCG
        }
        
	}
}