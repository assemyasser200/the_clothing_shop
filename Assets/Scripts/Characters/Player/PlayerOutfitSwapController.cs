using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutfitSwapController : MonoBehaviour, IShopCustomer
{
    [SerializeField] private PlayerSpriteResolver[] spriteResolvers;
    //rivate SpriteLibraryAsset libraryAsset => spriteLibrary.spriteLibraryAsset;

    public void BoughtItem(string label, string Category)
    {
        switch(Category)
        {
            case "Head":
            Debug.Log("Head");
                for(int i = 0; i < spriteResolvers.Length; i++)
                {
                    spriteResolvers[i].hairResolver.SetCategoryAndLabel(Category, label);
                }   
            break;

            case "Body":
            Debug.Log("Body");
                for(int i = 0; i < spriteResolvers.Length; i++)
                {
                    spriteResolvers[i].bodyResolver.SetCategoryAndLabel(Category, label);

                    if(spriteResolvers[i].leftArmResolver != null)
                    {
                        spriteResolvers[i].leftArmResolver.SetCategoryAndLabel("LeftArm", label);
                    }

                    if(spriteResolvers[i].rightArmResolver != null)
                    {
                        spriteResolvers[i].rightArmResolver.SetCategoryAndLabel("RightArm", label);
                    }
                }  
            break;

            case "LeftLeg":
            case "RightLeg":
            Debug.Log("Leg");
                for(int i = 0; i < spriteResolvers.Length; i++)
                {
                    if(spriteResolvers[i].leftLegResolver != null)
                    {
                        spriteResolvers[i].leftLegResolver.SetCategoryAndLabel("LeftLeg", label);
                    }

                    if(spriteResolvers[i].rightLegResolver != null)
                    {
                        spriteResolvers[i].rightLegResolver.SetCategoryAndLabel("RightLeg", label);
                    }
                }   
            break;
        }
    }
}
