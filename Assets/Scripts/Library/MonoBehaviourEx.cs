using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Playables;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.XR.WSA;

/// <summary>
/// 아래 기능을 제공하는 MonoBehaviour의 확장 클래스
/// 1) GameObject.name 과 이름이 같은 필드를 자동으로 로딩
/// 2) Build-in 컴퍼넌트 캐시
/// 3) Component의 모든 이벤트 핸들러를 가상 함수로 선언
/// 주의) 아래 메서드를 오버라이드하면 반드시 base의 해당 메서드를 호출하여야 함
/// Awake
/// OnDisable
/// </summary>
public class MonoBehaviourEx : MonoBehaviour
{
    #region Components Cache
    public virtual void OnDisable()
    {
        _components.Clear();
    }

    private readonly Dictionary<string, Component> _components = new Dictionary<string, Component>();

    public Image Image
    {
        get
        {
            if (_components.ContainsKey("Image") == false)
                _components.Add("Image", GetComponent<Image>());

            return (Image) _components["Image"];
        }
    }

    public AnchoredJoint2D AnchoredJoint2D
    {
        get
        {
            if (_components.ContainsKey("AnchoredJoint2D") == false)
                _components.Add("AnchoredJoint2D", GetComponent<AnchoredJoint2D>());

            return (AnchoredJoint2D) _components["AnchoredJoint2D"];
        }
    }

    public Animation Animation
    {
        get
        {
            if (_components.ContainsKey("Animation") == false)
                _components.Add("Animation", GetComponent<Animation>());

            return (Animation) _components["Animation"];
        }
    }

    public Animator Animator
    {
        get
        {
            if (_components.ContainsKey("Animator") == false)
                _components.Add("Animator", GetComponent<Animator>());

            return (Animator) _components["Animator"];
        }
    }

    public AreaEffector2D AreaEffector2D
    {
        get
        {
            if (_components.ContainsKey("AreaEffector2D") == false)
                _components.Add("AreaEffector2D", GetComponent<AreaEffector2D>());

            return (AreaEffector2D) _components["AreaEffector2D"];
        }
    }

    public AudioBehaviour AudioBehaviour
    {
        get
        {
            if (_components.ContainsKey("AudioBehaviour") == false)
                _components.Add("AudioBehaviour", GetComponent<AudioBehaviour>());

            return (AudioBehaviour) _components["AudioBehaviour"];
        }
    }

    public AudioChorusFilter AudioChorusFilter
    {
        get
        {
            if (_components.ContainsKey("AudioChorusFilter") == false)
                _components.Add("AudioChorusFilter", GetComponent<AudioChorusFilter>());

            return (AudioChorusFilter) _components["AudioChorusFilter"];
        }
    }

    public AudioDistortionFilter AudioDistortionFilter
    {
        get
        {
            if (_components.ContainsKey("AudioDistortionFilter") == false)
                _components.Add("AudioDistortionFilter", GetComponent<AudioDistortionFilter>());

            return (AudioDistortionFilter) _components["AudioDistortionFilter"];
        }
    }

    public AudioEchoFilter AudioEchoFilter
    {
        get
        {
            if (_components.ContainsKey("AudioEchoFilter") == false)
                _components.Add("AudioEchoFilter", GetComponent<AudioEchoFilter>());

            return (AudioEchoFilter) _components["AudioEchoFilter"];
        }
    }

    public AudioHighPassFilter AudioHighPassFilter
    {
        get
        {
            if (_components.ContainsKey("AudioHighPassFilter") == false)
                _components.Add("AudioHighPassFilter", GetComponent<AudioHighPassFilter>());

            return (AudioHighPassFilter) _components["AudioHighPassFilter"];
        }
    }

    public AudioListener AudioListener
    {
        get
        {
            if (_components.ContainsKey("AudioListener") == false)
                _components.Add("AudioListener", GetComponent<AudioListener>());

            return (AudioListener) _components["AudioListener"];
        }
    }

    public AudioLowPassFilter AudioLowPassFilter
    {
        get
        {
            if (_components.ContainsKey("AudioLowPassFilter") == false)
                _components.Add("AudioLowPassFilter", GetComponent<AudioLowPassFilter>());

            return (AudioLowPassFilter) _components["AudioLowPassFilter"];
        }
    }

    public AudioReverbFilter AudioReverbFilter
    {
        get
        {
            if (_components.ContainsKey("AudioReverbFilter") == false)
                _components.Add("AudioReverbFilter", GetComponent<AudioReverbFilter>());

            return (AudioReverbFilter) _components["AudioReverbFilter"];
        }
    }

    public AudioReverbZone AudioReverbZone
    {
        get
        {
            if (_components.ContainsKey("AudioReverbZone") == false)
                _components.Add("AudioReverbZone", GetComponent<AudioReverbZone>());

            return (AudioReverbZone) _components["AudioReverbZone"];
        }
    }

    public AudioSource AudioSource
    {
        get
        {
            if (_components.ContainsKey("AudioSource") == false)
                _components.Add("AudioSource", GetComponent<AudioSource>());

            return (AudioSource) _components["AudioSource"];
        }
    }

    public Behaviour Behaviour
    {
        get
        {
            if (_components.ContainsKey("Behaviour") == false)
                _components.Add("Behaviour", GetComponent<Behaviour>());

            return (Behaviour) _components["Behaviour"];
        }
    }

    public BillboardRenderer BillboardRenderer
    {
        get
        {
            if (_components.ContainsKey("BillboardRenderer") == false)
                _components.Add("BillboardRenderer", GetComponent<BillboardRenderer>());

            return (BillboardRenderer) _components["BillboardRenderer"];
        }
    }

    public BoxCollider BoxCollider
    {
        get
        {
            if (_components.ContainsKey("BoxCollider") == false)
                _components.Add("BoxCollider", GetComponent<BoxCollider>());

            return (BoxCollider) _components["BoxCollider"];
        }
    }

    public BoxCollider2D BoxCollider2D
    {
        get
        {
            if (_components.ContainsKey("BoxCollider2D") == false)
                _components.Add("BoxCollider2D", GetComponent<BoxCollider2D>());

            return (BoxCollider2D) _components["BoxCollider2D"];
        }
    }

    public BuoyancyEffector2D BuoyancyEffector2D
    {
        get
        {
            if (_components.ContainsKey("BuoyancyEffector2D") == false)
                _components.Add("BuoyancyEffector2D", GetComponent<BuoyancyEffector2D>());

            return (BuoyancyEffector2D) _components["BuoyancyEffector2D"];
        }
    }

    public Camera Camera
    {
        get
        {
            if (_components.ContainsKey("Camera") == false)
                _components.Add("Camera", GetComponent<Camera>());

            return (Camera) _components["Camera"];
        }
    }

    public Canvas Canvas
    {
        get
        {
            if (_components.ContainsKey("Canvas") == false)
                _components.Add("Canvas", GetComponent<Canvas>());

            return (Canvas) _components["Canvas"];
        }
    }

    public CanvasGroup CanvasGroup
    {
        get
        {
            if (_components.ContainsKey("CanvasGroup") == false)
                _components.Add("CanvasGroup", GetComponent<CanvasGroup>());

            return (CanvasGroup) _components["CanvasGroup"];
        }
    }

    public CanvasRenderer CanvasRenderer
    {
        get
        {
            if (_components.ContainsKey("CanvasRenderer") == false)
                _components.Add("CanvasRenderer", GetComponent<CanvasRenderer>());

            return (CanvasRenderer) _components["CanvasRenderer"];
        }
    }

    public CapsuleCollider CapsuleCollider
    {
        get
        {
            if (_components.ContainsKey("CapsuleCollider") == false)
                _components.Add("CapsuleCollider", GetComponent<CapsuleCollider>());

            return (CapsuleCollider) _components["CapsuleCollider"];
        }
    }

    public CapsuleCollider2D CapsuleCollider2D
    {
        get
        {
            if (_components.ContainsKey("CapsuleCollider2D") == false)
                _components.Add("CapsuleCollider2D", GetComponent<CapsuleCollider2D>());

            return (CapsuleCollider2D) _components["CapsuleCollider2D"];
        }
    }

    public CharacterController CharacterController
    {
        get
        {
            if (_components.ContainsKey("CharacterController") == false)
                _components.Add("CharacterController", GetComponent<CharacterController>());

            return (CharacterController) _components["CharacterController"];
        }
    }

    public CharacterJoint CharacterJoint
    {
        get
        {
            if (_components.ContainsKey("CharacterJoint") == false)
                _components.Add("CharacterJoint", GetComponent<CharacterJoint>());

            return (CharacterJoint) _components["CharacterJoint"];
        }
    }

    public CircleCollider2D CircleCollider2D
    {
        get
        {
            if (_components.ContainsKey("CircleCollider2D") == false)
                _components.Add("CircleCollider2D", GetComponent<CircleCollider2D>());

            return (CircleCollider2D) _components["CircleCollider2D"];
        }
    }

    public Cloth Cloth
    {
        get
        {
            if (_components.ContainsKey("Cloth") == false)
                _components.Add("Cloth", GetComponent<Cloth>());

            return (Cloth) _components["Cloth"];
        }
    }

    public Collider Collider
    {
        get
        {
            if (_components.ContainsKey("Collider") == false)
                _components.Add("Collider", GetComponent<Collider>());

            return (Collider) _components["Collider"];
        }
    }

    public Collider2D Collider2D
    {
        get
        {
            if (_components.ContainsKey("Collider2D") == false)
                _components.Add("Collider2D", GetComponent<Collider2D>());

            return (Collider2D) _components["Collider2D"];
        }
    }

    public Component Component
    {
        get
        {
            if (_components.ContainsKey("Component") == false)
                _components.Add("Component", GetComponent<Component>());

            return _components["Component"];
        }
    }

    public CompositeCollider2D CompositeCollider2D
    {
        get
        {
            if (_components.ContainsKey("CompositeCollider2D") == false)
                _components.Add("CompositeCollider2D", GetComponent<CompositeCollider2D>());

            return (CompositeCollider2D) _components["CompositeCollider2D"];
        }
    }

    public ConfigurableJoint ConfigurableJoint
    {
        get
        {
            if (_components.ContainsKey("ConfigurableJoint") == false)
                _components.Add("ConfigurableJoint", GetComponent<ConfigurableJoint>());

            return (ConfigurableJoint) _components["ConfigurableJoint"];
        }
    }

    public ConstantForce ConstantForce
    {
        get
        {
            if (_components.ContainsKey("ConstantForce") == false)
                _components.Add("ConstantForce", GetComponent<ConstantForce>());

            return (ConstantForce) _components["ConstantForce"];
        }
    }

    public ConstantForce2D ConstantForce2D
    {
        get
        {
            if (_components.ContainsKey("ConstantForce2D") == false)
                _components.Add("ConstantForce2D", GetComponent<ConstantForce2D>());

            return (ConstantForce2D) _components["ConstantForce2D"];
        }
    }

    public DistanceJoint2D DistanceJoint2D
    {
        get
        {
            if (_components.ContainsKey("DistanceJoint2D") == false)
                _components.Add("DistanceJoint2D", GetComponent<DistanceJoint2D>());

            return (DistanceJoint2D) _components["DistanceJoint2D"];
        }
    }

    public EdgeCollider2D EdgeCollider2D
    {
        get
        {
            if (_components.ContainsKey("EdgeCollider2D") == false)
                _components.Add("EdgeCollider2D", GetComponent<EdgeCollider2D>());

            return (EdgeCollider2D) _components["EdgeCollider2D"];
        }
    }

    public Effector2D Effector2D
    {
        get
        {
            if (_components.ContainsKey("Effector2D") == false)
                _components.Add("Effector2D", GetComponent<Effector2D>());

            return (Effector2D) _components["Effector2D"];
        }
    }

    public FixedJoint FixedJoint
    {
        get
        {
            if (_components.ContainsKey("FixedJoint") == false)
                _components.Add("FixedJoint", GetComponent<FixedJoint>());

            return (FixedJoint) _components["FixedJoint"];
        }
    }

    public FixedJoint2D FixedJoint2D
    {
        get
        {
            if (_components.ContainsKey("FixedJoint2D") == false)
                _components.Add("FixedJoint2D", GetComponent<FixedJoint2D>());

            return (FixedJoint2D) _components["FixedJoint2D"];
        }
    }

    public FlareLayer FlareLayer
    {
        get
        {
            if (_components.ContainsKey("FlareLayer") == false)
                _components.Add("FlareLayer", GetComponent<FlareLayer>());

            return (FlareLayer) _components["FlareLayer"];
        }
    }

    public FrictionJoint2D FrictionJoint2D
    {
        get
        {
            if (_components.ContainsKey("FrictionJoint2D") == false)
                _components.Add("FrictionJoint2D", GetComponent<FrictionJoint2D>());

            return (FrictionJoint2D) _components["FrictionJoint2D"];
        }
    }

    public Grid Grid
    {
        get
        {
            if (_components.ContainsKey("Grid") == false)
                _components.Add("Grid", GetComponent<Grid>());

            return (Grid) _components["Grid"];
        }
    }

    public GridLayout GridLayout
    {
        get
        {
            if (_components.ContainsKey("GridLayout") == false)
                _components.Add("GridLayout", GetComponent<GridLayout>());

            return (GridLayout) _components["GridLayout"];
        }
    }

    public GUIElement GUIElement
    {
        get
        {
            if (_components.ContainsKey("GUIElement") == false)
                _components.Add("GUIElement", GetComponent<GUIElement>());

            return (GUIElement) _components["GUIElement"];
        }
    }

    public Text Text
    {
        get
        {
            if (_components.ContainsKey("Text") == false)
                _components.Add("Text", GetComponent<Text>());

            return (Text) _components["Text"];
        }
    }

    public HingeJoint HingeJoint
    {
        get
        {
            if (_components.ContainsKey("HingeJoint") == false)
                _components.Add("HingeJoint", GetComponent<HingeJoint>());

            return (HingeJoint) _components["HingeJoint"];
        }
    }

    public HingeJoint2D HingeJoint2D
    {
        get
        {
            if (_components.ContainsKey("HingeJoint2D") == false)
                _components.Add("HingeJoint2D", GetComponent<HingeJoint2D>());

            return (HingeJoint2D) _components["HingeJoint2D"];
        }
    }

    public Joint Joint
    {
        get
        {
            if (_components.ContainsKey("Joint") == false)
                _components.Add("Joint", GetComponent<Joint>());

            return (Joint) _components["Joint"];
        }
    }

    public Joint2D Joint2D
    {
        get
        {
            if (_components.ContainsKey("Joint2D") == false)
                _components.Add("Joint2D", GetComponent<Joint2D>());

            return (Joint2D) _components["Joint2D"];
        }
    }

    public LensFlare LensFlare
    {
        get
        {
            if (_components.ContainsKey("LensFlare") == false)
                _components.Add("LensFlare", GetComponent<LensFlare>());

            return (LensFlare) _components["LensFlare"];
        }
    }

    public Light Light
    {
        get
        {
            if (_components.ContainsKey("Light") == false)
                _components.Add("Light", GetComponent<Light>());

            return (Light) _components["Light"];
        }
    }

    public LightProbeGroup LightProbeGroup
    {
        get
        {
            if (_components.ContainsKey("LightProbeGroup") == false)
                _components.Add("LightProbeGroup", GetComponent<LightProbeGroup>());

            return (LightProbeGroup) _components["LightProbeGroup"];
        }
    }

    public LightProbeProxyVolume LightProbeProxyVolume
    {
        get
        {
            if (_components.ContainsKey("LightProbeProxyVolume") == false)
                _components.Add("LightProbeProxyVolume", GetComponent<LightProbeProxyVolume>());

            return (LightProbeProxyVolume) _components["LightProbeProxyVolume"];
        }
    }

    public LineRenderer LineRenderer
    {
        get
        {
            if (_components.ContainsKey("LineRenderer") == false)
                _components.Add("LineRenderer", GetComponent<LineRenderer>());

            return (LineRenderer) _components["LineRenderer"];
        }
    }

    public LODGroup LODGroup
    {
        get
        {
            if (_components.ContainsKey("LODGroup") == false)
                _components.Add("LODGroup", GetComponent<LODGroup>());

            return (LODGroup) _components["LODGroup"];
        }
    }

    public MeshCollider MeshCollider
    {
        get
        {
            if (_components.ContainsKey("MeshCollider") == false)
                _components.Add("MeshCollider", GetComponent<MeshCollider>());

            return (MeshCollider) _components["MeshCollider"];
        }
    }

    public MeshFilter MeshFilter
    {
        get
        {
            if (_components.ContainsKey("MeshFilter") == false)
                _components.Add("MeshFilter", GetComponent<MeshFilter>());

            return (MeshFilter) _components["MeshFilter"];
        }
    }

    public MeshRenderer MeshRenderer
    {
        get
        {
            if (_components.ContainsKey("MeshRenderer") == false)
                _components.Add("MeshRenderer", GetComponent<MeshRenderer>());

            return (MeshRenderer) _components["MeshRenderer"];
        }
    }

    public MonoBehaviour MonoBehaviour
    {
        get
        {
            if (_components.ContainsKey("MonoBehaviour") == false)
                _components.Add("MonoBehaviour", GetComponent<MonoBehaviour>());

            return (MonoBehaviour) _components["MonoBehaviour"];
        }
    }

    public NavMeshAgent NavMeshAgent
    {
        get
        {
            if (_components.ContainsKey("NavMeshAgent") == false)
                _components.Add("NavMeshAgent", GetComponent<NavMeshAgent>());

            return (NavMeshAgent) _components["NavMeshAgent"];
        }
    }

    public NavMeshObstacle NavMeshObstacle
    {
        get
        {
            if (_components.ContainsKey("NavMeshObstacle") == false)
                _components.Add("NavMeshObstacle", GetComponent<NavMeshObstacle>());

            return (NavMeshObstacle) _components["NavMeshObstacle"];
        }
    }

    public NetworkMatch NetworkMatch
    {
        get
        {
            if (_components.ContainsKey("NetworkMatch") == false)
                _components.Add("NetworkMatch", GetComponent<NetworkMatch>());

            return (NetworkMatch) _components["NetworkMatch"];
        }
    }

    public NetworkIdentity NetworkIdentity
    {
        get
        {
            if (_components.ContainsKey("NetworkIdentity") == false)
                _components.Add("NetworkIdentity", GetComponent<NetworkIdentity>());

            return (NetworkIdentity) _components["NetworkIdentity"];
        }
    }

    public OcclusionArea OcclusionArea
    {
        get
        {
            if (_components.ContainsKey("OcclusionArea") == false)
                _components.Add("OcclusionArea", GetComponent<OcclusionArea>());

            return (OcclusionArea) _components["OcclusionArea"];
        }
    }

    public OcclusionPortal OcclusionPortal
    {
        get
        {
            if (_components.ContainsKey("OcclusionPortal") == false)
                _components.Add("OcclusionPortal", GetComponent<OcclusionPortal>());

            return (OcclusionPortal) _components["OcclusionPortal"];
        }
    }

    public OffMeshLink OffMeshLink
    {
        get
        {
            if (_components.ContainsKey("OffMeshLink") == false)
                _components.Add("OffMeshLink", GetComponent<OffMeshLink>());

            return (OffMeshLink) _components["OffMeshLink"];
        }
    }

    public ParticleSystem ParticleSystem
    {
        get
        {
            if (_components.ContainsKey("ParticleSystem") == false)
                _components.Add("ParticleSystem", GetComponent<ParticleSystem>());

            return (ParticleSystem) _components["ParticleSystem"];
        }
    }

    public ParticleSystemRenderer ParticleSystemRenderer
    {
        get
        {
            if (_components.ContainsKey("ParticleSystemRenderer") == false)
                _components.Add("ParticleSystemRenderer", GetComponent<ParticleSystemRenderer>());

            return (ParticleSystemRenderer) _components["ParticleSystemRenderer"];
        }
    }

    public PhysicsUpdateBehaviour2D PhysicsUpdateBehaviour2D
    {
        get
        {
            if (_components.ContainsKey("PhysicsUpdateBehaviour2D") == false)
                _components.Add("PhysicsUpdateBehaviour2D", GetComponent<PhysicsUpdateBehaviour2D>());

            return (PhysicsUpdateBehaviour2D) _components["PhysicsUpdateBehaviour2D"];
        }
    }

    public PlatformEffector2D PlatformEffector2D
    {
        get
        {
            if (_components.ContainsKey("PlatformEffector2D") == false)
                _components.Add("PlatformEffector2D", GetComponent<PlatformEffector2D>());

            return (PlatformEffector2D) _components["PlatformEffector2D"];
        }
    }

    public PlayableDirector PlayableDirector
    {
        get
        {
            if (_components.ContainsKey("PlayableDirector") == false)
                _components.Add("PlayableDirector", GetComponent<PlayableDirector>());

            return (PlayableDirector) _components["PlayableDirector"];
        }
    }

    public PointEffector2D PointEffector2D
    {
        get
        {
            if (_components.ContainsKey("PointEffector2D") == false)
                _components.Add("PointEffector2D", GetComponent<PointEffector2D>());

            return (PointEffector2D) _components["PointEffector2D"];
        }
    }

    public PolygonCollider2D PolygonCollider2D
    {
        get
        {
            if (_components.ContainsKey("PolygonCollider2D") == false)
                _components.Add("PolygonCollider2D", GetComponent<PolygonCollider2D>());

            return (PolygonCollider2D) _components["PolygonCollider2D"];
        }
    }

    public Projector Projector
    {
        get
        {
            if (_components.ContainsKey("Projector") == false)
                _components.Add("Projector", GetComponent<Projector>());

            return (Projector) _components["Projector"];
        }
    }

    public RectTransform RectTransform
    {
        get
        {
            if (_components.ContainsKey("RectTransform") == false)
                _components.Add("RectTransform", GetComponent<RectTransform>());

            return (RectTransform) _components["RectTransform"];
        }
    }

    public ReflectionProbe ReflectionProbe
    {
        get
        {
            if (_components.ContainsKey("ReflectionProbe") == false)
                _components.Add("ReflectionProbe", GetComponent<ReflectionProbe>());

            return (ReflectionProbe) _components["ReflectionProbe"];
        }
    }

    public RelativeJoint2D RelativeJoint2D
    {
        get
        {
            if (_components.ContainsKey("RelativeJoint2D") == false)
                _components.Add("RelativeJoint2D", GetComponent<RelativeJoint2D>());

            return (RelativeJoint2D) _components["RelativeJoint2D"];
        }
    }

    public Renderer Renderer
    {
        get
        {
            if (_components.ContainsKey("Renderer") == false)
                _components.Add("Renderer", GetComponent<Renderer>());

            return (Renderer) _components["Renderer"];
        }
    }

    public Rigidbody Rigidbody
    {
        get
        {
            if (_components.ContainsKey("Rigidbody") == false)
                _components.Add("Rigidbody", GetComponent<Rigidbody>());

            return (Rigidbody) _components["Rigidbody"];
        }
    }

    public Rigidbody2D Rigidbody2D
    {
        get
        {
            if (_components.ContainsKey("Rigidbody2D") == false)
                _components.Add("Rigidbody2D", GetComponent<Rigidbody2D>());

            return (Rigidbody2D) _components["Rigidbody2D"];
        }
    }

    public SkinnedMeshRenderer SkinnedMeshRenderer
    {
        get
        {
            if (_components.ContainsKey("SkinnedMeshRenderer") == false)
                _components.Add("SkinnedMeshRenderer", GetComponent<SkinnedMeshRenderer>());

            return (SkinnedMeshRenderer) _components["SkinnedMeshRenderer"];
        }
    }

    public Skybox Skybox
    {
        get
        {
            if (_components.ContainsKey("Skybox") == false)
                _components.Add("Skybox", GetComponent<Skybox>());

            return (Skybox) _components["Skybox"];
        }
    }

    public SliderJoint2D SliderJoint2D
    {
        get
        {
            if (_components.ContainsKey("SliderJoint2D") == false)
                _components.Add("SliderJoint2D", GetComponent<SliderJoint2D>());

            return (SliderJoint2D) _components["SliderJoint2D"];
        }
    }

    public SortingGroup SortingGroup
    {
        get
        {
            if (_components.ContainsKey("SortingGroup") == false)
                _components.Add("SortingGroup", GetComponent<SortingGroup>());

            return (SortingGroup) _components["SortingGroup"];
        }
    }

    public SphereCollider SphereCollider
    {
        get
        {
            if (_components.ContainsKey("SphereCollider") == false)
                _components.Add("SphereCollider", GetComponent<SphereCollider>());

            return (SphereCollider) _components["SphereCollider"];
        }
    }

    public SpringJoint SpringJoint
    {
        get
        {
            if (_components.ContainsKey("SpringJoint") == false)
                _components.Add("SpringJoint", GetComponent<SpringJoint>());

            return (SpringJoint) _components["SpringJoint"];
        }
    }

    public SpringJoint2D SpringJoint2D
    {
        get
        {
            if (_components.ContainsKey("SpringJoint2D") == false)
                _components.Add("SpringJoint2D", GetComponent<SpringJoint2D>());

            return (SpringJoint2D) _components["SpringJoint2D"];
        }
    }

    public SpriteMask SpriteMask
    {
        get
        {
            if (_components.ContainsKey("SpriteMask") == false)
                _components.Add("SpriteMask", GetComponent<SpriteMask>());

            return (SpriteMask) _components["SpriteMask"];
        }
    }

    public SpriteRenderer SpriteRenderer
    {
        get
        {
            if (_components.ContainsKey("SpriteRenderer") == false)
                _components.Add("SpriteRenderer", GetComponent<SpriteRenderer>());

            return (SpriteRenderer) _components["SpriteRenderer"];
        }
    }

    public SurfaceEffector2D SurfaceEffector2D
    {
        get
        {
            if (_components.ContainsKey("SurfaceEffector2D") == false)
                _components.Add("SurfaceEffector2D", GetComponent<SurfaceEffector2D>());

            return (SurfaceEffector2D) _components["SurfaceEffector2D"];
        }
    }

    public TargetJoint2D TargetJoint2D
    {
        get
        {
            if (_components.ContainsKey("TargetJoint2D") == false)
                _components.Add("TargetJoint2D", GetComponent<TargetJoint2D>());

            return (TargetJoint2D) _components["TargetJoint2D"];
        }
    }

    public Terrain Terrain
    {
        get
        {
            if (_components.ContainsKey("Terrain") == false)
                _components.Add("Terrain", GetComponent<Terrain>());

            return (Terrain) _components["Terrain"];
        }
    }

    public TerrainCollider TerrainCollider
    {
        get
        {
            if (_components.ContainsKey("TerrainCollider") == false)
                _components.Add("TerrainCollider", GetComponent<TerrainCollider>());

            return (TerrainCollider) _components["TerrainCollider"];
        }
    }

    public TextMesh TextMesh
    {
        get
        {
            if (_components.ContainsKey("TextMesh") == false)
                _components.Add("TextMesh", GetComponent<TextMesh>());

            return (TextMesh) _components["TextMesh"];
        }
    }

    public Tilemap Tilemap
    {
        get
        {
            if (_components.ContainsKey("Tilemap") == false)
                _components.Add("Tilemap", GetComponent<Tilemap>());

            return (Tilemap) _components["Tilemap"];
        }
    }

    public TilemapCollider2D TilemapCollider2D
    {
        get
        {
            if (_components.ContainsKey("TilemapCollider2D") == false)
                _components.Add("TilemapCollider2D", GetComponent<TilemapCollider2D>());

            return (TilemapCollider2D) _components["TilemapCollider2D"];
        }
    }

    public TilemapRenderer TilemapRenderer
    {
        get
        {
            if (_components.ContainsKey("TilemapRenderer") == false)
                _components.Add("TilemapRenderer", GetComponent<TilemapRenderer>());

            return (TilemapRenderer) _components["TilemapRenderer"];
        }
    }

    public TrailRenderer TrailRenderer
    {
        get
        {
            if (_components.ContainsKey("TrailRenderer") == false)
                _components.Add("TrailRenderer", GetComponent<TrailRenderer>());

            return (TrailRenderer) _components["TrailRenderer"];
        }
    }

    public Transform Transform
    {
        get
        {
            if (_components.ContainsKey("Transform") == false)
                _components.Add("Transform", GetComponent<Transform>());

            return (Transform) _components["Transform"];
        }
    }

    public Tree Tree
    {
        get
        {
            if (_components.ContainsKey("Tree") == false)
                _components.Add("Tree", GetComponent<Tree>());

            return (Tree) _components["Tree"];
        }
    }

    public VideoPlayer VideoPlayer
    {
        get
        {
            if (_components.ContainsKey("VideoPlayer") == false)
                _components.Add("VideoPlayer", GetComponent<VideoPlayer>());

            return (VideoPlayer) _components["VideoPlayer"];
        }
    }

    public WheelCollider WheelCollider
    {
        get
        {
            if (_components.ContainsKey("WheelCollider") == false)
                _components.Add("WheelCollider", GetComponent<WheelCollider>());

            return (WheelCollider) _components["WheelCollider"];
        }
    }

    public WheelJoint2D WheelJoint2D
    {
        get
        {
            if (_components.ContainsKey("WheelJoint2D") == false)
                _components.Add("WheelJoint2D", GetComponent<WheelJoint2D>());

            return (WheelJoint2D) _components["WheelJoint2D"];
        }
    }

    public WindZone WindZone
    {
        get
        {
            if (_components.ContainsKey("WindZone") == false)
                _components.Add("WindZone", GetComponent<WindZone>());

            return (WindZone) _components["WindZone"];
        }
    }

    public WorldAnchor WorldAnchor
    {
        get
        {
            if (_components.ContainsKey("WorldAnchor") == false)
                _components.Add("WorldAnchor", GetComponent<WorldAnchor>());

            return (WorldAnchor) _components["WorldAnchor"];
        }
    }
    #endregion

    #region Overriden EventHandlers
    protected virtual void FixedUpdate()
    {
    }

    protected virtual void LateUpdate()
    {
    }

    protected virtual void OnAnimatorIK(int layerIndex)
    {
    }

    protected virtual void OnAnimatorMove()
    {
    }

    protected virtual void OnApplicationFocus(bool focusStatus)
    {
    }

    protected virtual void OnApplicationPause(bool pauseStatus)
    {
    }

    protected virtual void OnApplicationQuit()
    {
    }

    protected virtual void OnAudioFilterRead(float[] data, int channels)
    {
    }

    protected virtual void OnBecameInvisible()
    {
    }

    protected virtual void OnBecameVisible()
    {
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
    }

    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
    }

    protected virtual void OnCollisionExit(Collision collisionInfo)
    {
    }

    protected virtual void OnCollisionExit2D(Collision2D coll)
    {
    }

    protected virtual void OnCollisionStay(Collision collisionInfo)
    {
    }

    protected virtual void OnCollisionStay2D(Collision2D coll)
    {
    }

    protected virtual void OnConnectedToServer()
    {
    }

    protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
    {
    }

    protected virtual void OnDestroy()
    {
    }

    protected virtual void OnDisconnectedFromServer(NetworkDisconnection info)
    {
    }

    protected virtual void OnDrawGizmos()
    {
    }

    protected virtual void OnDrawGizmosSelected()
    {
    }

    protected virtual void OnEnable()
    {
    }

    protected virtual void OnFailedToConnect(NetworkConnectionError error)
    {
    }

    protected virtual void OnFailedToConnectToMasterServer(NetworkConnectionError info)
    {
    }

    protected virtual void OnGUI()
    {
    }

    protected virtual void OnJointBreak(float breakForce)
    {
    }

    protected virtual void OnJointBreak2D(Joint2D brokenJoint)
    {
    }

    protected virtual void OnMasterServerEvent(MasterServerEvent msEvent)
    {
    }

    protected virtual void OnMouseDown()
    {
    }

    protected virtual void OnMouseDrag()
    {
    }

    protected virtual void OnMouseEnter()
    {
    }

    protected virtual void OnMouseOver()
    {
    }

    protected virtual void OnMouseUp()
    {
    }

    protected virtual void OnMouseUpAsButton()
    {
    }

    protected virtual void OnNetworkInstantiate(NetworkMessageInfo info)
    {
    }

    protected virtual void OnParticleCollision(GameObject other)
    {
    }

    protected virtual void OnPlayerConnected(NetworkPlayer player)
    {
    }

    protected virtual void OnPlayerDisconnected(NetworkPlayer player)
    {
    }

    protected virtual void OnPostRender()
    {
    }

    protected virtual void OnPreCull()
    {
    }

    protected virtual void OnPreRender()
    {
    }

    protected virtual void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
    }

    protected virtual void OnRenderObject()
    {
    }

    protected virtual void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
    }

    protected virtual void OnServerInitialized()
    {
    }

    protected virtual void OnTransformChildrenChanged()
    {
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
    }

    protected virtual void OnTriggerExit(Collider other)
    {
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
    }

    protected virtual void OnTriggerStay(Collider other)
    {
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
    }

    protected virtual void OnValidate()
    {
    }

    protected virtual void OnWillRenderObject()
    {
    }

    protected virtual void Reset()
    {
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }
    #endregion
}
