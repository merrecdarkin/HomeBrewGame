using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags : MonoBehaviour
{
   [SerializeField] private List<Tag> _tags;

   public List<Tag> All =>  _tags;

   public bool HasTag(Tag tagcheckVar) { 
        return _tags.Contains(tagcheckVar);
   }

    
   public bool HasTag(string tagName){
        return _tags.Exists(tagcheckVar => tagcheckVar.Name == tagName);
   }

}
