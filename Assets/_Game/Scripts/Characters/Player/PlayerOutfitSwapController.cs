using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutfitSwapController : MonoBehaviour, IShopCustomer
{
    [SerializeField] private PlayerSpriteResolver[] spriteResolvers;
    //rivate SpriteLibraryAsset libraryAsset => spriteLibrary.spriteLibraryAsset;

    public void SetPlayerDefaultOutfit()
    {
        SetHair("Hair", "Default"); 
        SetHat("Hat", "Default");
        SetMiddleFace("MiddleFace", "Default");
        SetBody("Body", "Default");
        SetLeg("LeftLeg", "Default");
    }

    void SetHair(string label, string Category)
    {
        for(int i = 0; i < spriteResolvers.Length; i++)
        {
            spriteResolvers[i].hairResolver.SetCategoryAndLabel(Category, label);
        }   
    }

    void SetHat(string label, string Category)
    {
        for(int i = 0; i < spriteResolvers.Length; i++)
        {
            spriteResolvers[i].hatResolver.SetCategoryAndLabel(Category, label);
            spriteResolvers[i].middleFaceResolver.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }    
    }

    void SetMiddleFace(string label, string Category)
    {
        for(int i = 0; i < spriteResolvers.Length; i++)
        {
            spriteResolvers[i].middleFaceResolver.SetCategoryAndLabel(Category, label);
            spriteResolvers[i].hatResolver.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            //spriteResolvers[i].hairResolver.GetComponent<SpriteRenderer>().sprite = null;
        }   
    }

    void SetBody(string label, string Category)
    {
        for(int i = 0; i < spriteResolvers.Length; i++)
        {
            spriteResolvers[i].bodyResolver.SetCategoryAndLabel(Category, label);

            if(spriteResolvers[i].leftArmResolver != null)
            {
             //   Debug.Log("leftArmResolver");
                spriteResolvers[i].leftArmResolver.SetCategoryAndLabel("LeftArm", label);
            }

            if(spriteResolvers[i].rightArmResolver != null)
            {
//                Debug.Log("rightArmResolver");
                spriteResolvers[i].rightArmResolver.SetCategoryAndLabel("RightArm", label);
            }
        }  
    }

    void SetLeg(string label, string Category)
    {
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
    }

    public void BoughtItem(string label, string Category)
    {
        switch(Category)
        {
            case "Hair":
                SetHair(label, Category);
            break;

            case "Hat":
                SetHat(label, Category);
            break;

            case "MiddleFace":
                SetMiddleFace(label, Category);
            break;

            case "Body":
                SetBody(label, Category);
                
            break;

            case "LeftLeg":
            case "RightLeg":
                SetLeg(label, Category);
            break;
        }
    }

    public bool CheckAvailableCoins(int price)
    {
        if(GetComponent<PlayerCoins>().GetCoins() < price)
        {
            return false;
        }
        else
        {
            GetComponent<PlayerCoins>().DeductCoins(price);
            return true;
        }
    }
}
