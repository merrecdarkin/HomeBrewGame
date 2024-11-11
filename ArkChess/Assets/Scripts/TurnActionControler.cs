using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class TurnActionControler : MonoBehaviour
{
    public class ActorTracker{
        public GameObject ActorOfRound;
        public int ActorSpeed;

        public ActorTracker(GameObject AcOfRou, int ASpe){
            ActorOfRound= AcOfRou;
            ActorSpeed=ASpe; 
        } 
    }

    public List<Transform> ActorsList;
    public List<int> ActorsSpeedList;

    public List<ActorTracker> TrackingActors;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTurn(){

    }

    public void RemoveActor(){

    }
    
    public void AddActor(GameObject NewActorAdding, int ActorSpeed){
        TrackingActors.Add(new ActorTracker(NewActorAdding, ActorSpeed));
        if (TrackingActors.Count>2){
            SortTurnActor(TrackingActors.Count-1);
        }
    }
    // Newest entries will be slot in last, if they are slower than the one before them, they will be push forward until the cannot be push anymore
    private void SortTurnActor(int NewestEntry){
        while ((NewestEntry>0)&&(TrackingActors[NewestEntry-1].ActorSpeed>TrackingActors[NewestEntry].ActorSpeed)){
            
                ActorTracker TempAcSlot= TrackingActors[NewestEntry-1]; //temp slot to swap
                TrackingActors[NewestEntry-1]= TrackingActors[NewestEntry];
                TrackingActors[NewestEntry]= TempAcSlot;
                NewestEntry--;
    
        }

    }

}
