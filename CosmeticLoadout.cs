using UnityEngine;

[CreateAssetMenu(menuName = "Elite Battleground/Cosmetic Loadout")]
public class CosmeticLoadout : ScriptableObject
{
    public string outfitId = "default_outfit"; public string helmetSkinId = "default_helmet";
    public string backpackSkinId = "default_bag"; public string weaponSkinId = "default_weapon";
    public Material outfitMaterial; public Material weaponMaterial;
}
