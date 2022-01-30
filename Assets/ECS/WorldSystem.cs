using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;
using Unity.Jobs;
using System.IO;

public class WorldSystem : MonoBehaviour
{
    public TextAsset data;
    StringReader text;
    string line;

    [SerializeField] private Mesh star;
    [SerializeField] private Material[] mate;
    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        text = new StringReader(data.text);
        line = text.ReadLine();
        EntityArchetype archetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(RenderMesh),
            typeof(RenderBounds),
            typeof(LocalToWorld),
            typeof(Scale)
           
            );
        while ((line != null))
        {
            NativeArray<Entity> entities = new NativeArray<Entity>(10000, Allocator.Temp);
            entityManager.CreateEntity(archetype, entities);


            for (int i = 0; i < entities.Length; i++)
            {

                try
                {

                    string[] split = line.Split(',');

                    Entity entity = entities[i];
                    entityManager.SetComponentData(entity, new Translation { Value = new float3(float.Parse(split[0]) * 50, float.Parse(split[1]) * 50, float.Parse(split[2]) * 50) });
                    entityManager.SetComponentData(entity, new Scale { Value = Mathf.Log10(float.Parse(split[4]))  });


                    //Material mater = new Material(mate); 
                    //mater.color = new Color32((byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), (byte)UnityEngine.Random.Range(0, 255), 255);

                    byte tmp = 0;
                    if (double.Parse(split[3]) >= 113017) tmp = 48;
                    else if (double.Parse(split[3]) >= 56701) tmp = 47;
                    else if (double.Parse(split[3]) >= 33605) tmp = 46;
                    else if (double.Parse(split[3]) >= 22695) tmp = 45;
                    else if (double.Parse(split[3]) >= 16954) tmp = 44;
                    else if (double.Parse(split[3]) >= 13674) tmp = 43;
                    else if (double.Parse(split[3]) >= 11677) tmp = 42;
                    else if (double.Parse(split[3]) >= 10395) tmp = 41;
                    else if (double.Parse(split[3]) >= 9531) tmp = 40;
                    else if (double.Parse(split[3]) >= 8917) tmp = 39;
                    else if (double.Parse(split[3]) >= 8455) tmp = 38;
                    else if (double.Parse(split[3]) >= 8084) tmp = 37;
                    else if (double.Parse(split[3]) >= 7767) tmp = 36;
                    else if (double.Parse(split[3]) >= 7483) tmp = 35;
                    else if (double.Parse(split[3]) >= 7218) tmp = 34;
                    else if (double.Parse(split[3]) >= 6967) tmp = 33;
                    else if (double.Parse(split[3]) >= 6728) tmp = 32;
                    else if (double.Parse(split[3]) >= 6500) tmp = 31;
                    else if (double.Parse(split[3]) >= 6285) tmp = 30;
                    else if (double.Parse(split[3]) >= 6082) tmp = 29;
                    else if (double.Parse(split[3]) >= 5895) tmp = 28;
                    else if (double.Parse(split[3]) >= 5722) tmp = 27;
                    else if (double.Parse(split[3]) >= 5563) tmp = 26;
                    else if (double.Parse(split[3]) >= 5418) tmp = 25;
                    else if (double.Parse(split[3]) >= 5286) tmp = 24;
                    else if (double.Parse(split[3]) >= 5164) tmp = 23;
                    else if (double.Parse(split[3]) >= 5052) tmp = 22;
                    else if (double.Parse(split[3]) >= 4948) tmp = 21;
                    else if (double.Parse(split[3]) >= 4849) tmp = 20;
                    else if (double.Parse(split[3]) >= 4755) tmp = 19;
                    else if (double.Parse(split[3]) >= 4664) tmp = 18;
                    else if (double.Parse(split[3]) >= 4576) tmp = 17;
                    else if (double.Parse(split[3]) >= 4489) tmp = 16;
                    else if (double.Parse(split[3]) >= 4405) tmp = 15;
                    else if (double.Parse(split[3]) >= 4322) tmp = 14;
                    else if (double.Parse(split[3]) >= 4241) tmp = 13;
                    else if (double.Parse(split[3]) >= 4159) tmp = 12;
                    else if (double.Parse(split[3]) >= 4076) tmp = 11;
                    else if (double.Parse(split[3]) >= 3989) tmp = 10;
                    else if (double.Parse(split[3]) >= 3892) tmp = 9;
                    else if (double.Parse(split[3]) >= 3779) tmp = 8;
                    else if (double.Parse(split[3]) >= 3640) tmp = 7;
                    else if (double.Parse(split[3]) >= 3463) tmp = 6;
                    else if (double.Parse(split[3]) >= 3234) tmp = 5;
                    else if (double.Parse(split[3]) >= 2942) tmp = 4;
                    else if (double.Parse(split[3]) >= 2579) tmp = 3;
                    else if (double.Parse(split[3]) >= 2150) tmp = 2;
                    else if (double.Parse(split[3]) >= 1675) tmp = 1;
                    else if (double.Parse(split[3]) >= 1195) tmp = 0;
                    entityManager.SetSharedComponentData(entity, new RenderMesh
                    {
                        mesh = star,
                        
                        material = mate[tmp],

                    });
                    //entityManager.AddComponentData(entity, new MyColorComponent { Value = new float4(1, 0, 0, 1) });
                    for (int w = 0; w < 10; w++)
                    {
                        line = text.ReadLine();
                    }

                }
                catch
                {

                }
                line = text.ReadLine();
            }
            entities.Dispose();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
[MaterialProperty("_MyColor", MaterialPropertyFormat.Float4)]
public struct MyColorComponent : IComponentData
{
    public float4 Value;
}