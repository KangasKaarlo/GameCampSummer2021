using UnityEngine;

public class LeverGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    // Update is called once per frame
    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }
    void GenerateTile(int x, int y)
    {
        Color currentPixel = map.GetPixel(x, y);

        //ignores empty tiles
        if (currentPixel.a == 0)
        {
            return;
        }
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(currentPixel))
            {
                Vector2 position = new Vector2(x, y - 5.5f);
                Instantiate(colorMapping.prefab, position, Quaternion.identity);
            }
        }
    }
}
