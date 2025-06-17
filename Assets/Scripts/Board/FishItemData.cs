using UnityEngine;

[CreateAssetMenu(fileName = "FishItemData", menuName = "Match3/Fish Item Data")]
public class FishItemData : ScriptableObject
{
    [System.Serializable]
    public class FishTextureData
    {
        public NormalItem.eNormalType itemType;
        public Sprite fishSprite;
    }

    public FishTextureData[] fishTextures;

    public Sprite GetFishSprite(NormalItem.eNormalType type)
    {
        foreach (var fishData in fishTextures)
        {
            if (fishData.itemType == type)
            {
                return fishData.fishSprite;
            }
        }
        return null;
    }
} 