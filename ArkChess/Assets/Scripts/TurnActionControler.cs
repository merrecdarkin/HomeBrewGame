using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum ThisBattlePhase { STAGEINNIT, STARTTURN, ACTORCOUNT, ENEMYTURN, ALLYTURN, PLAYERTURN, EVENTTRIGGERTIME, COMBATCLEAR}

public class TurnActionControler : MonoBehaviour
{
    public class ActorTracker{
        public GameObject ActorOfRound;
        public int ActorRolledSpeed;

        public ActorTracker(GameObject AcOfRou, int ASpe){
            ActorOfRound= AcOfRou;
            ActorRolledSpeed=ASpe; 
        } 
    }
    public ThisBattlePhase TurnState;
/*    public List<Transform> ActorsList;
    public List<int> ActorsSpeedList;*/

    public List<ActorTracker> TrackingActors= new List<ActorTracker>();
    public List<GameObject> ActorListTest;
    
    public int CountedActors;
    public ActorTracker Testtracker;
    // Start is called before the first frame update
    void Start()
    {
        //TrackingActors= new List<ActorTracker>;

        TurnState= ThisBattlePhase.STAGEINNIT;
        LoadInStagePara();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTurn(){

    }

    public void RemoveActor (){
        TrackingActors= new List<ActorTracker>();
    }
    
    public void AddActor(GameObject NewActorAdding, int ActorSpeed){
        //Testtracker= new ActorTracker(NewActorAdding, ActorSpeed);

        //ActorListTest.Add(NewActorAdding);
        TrackingActors.Add(new ActorTracker(NewActorAdding, ActorSpeed));
        

        //TrackingActors.Add(Testtracker);        
        
        Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        if (TrackingActors.Count>2){
            SortTurnActor(TrackingActors.Count-1);
        }
        CountedActors=TrackingActors.Count;
        foreach (ActorTracker trackedActor in TrackingActors) {

            Debug.Log(trackedActor.ActorOfRound.name+ " Rolled a  "+ trackedActor.ActorRolledSpeed.ToString());

        }
        Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }
    // Newest entries will be slot in last, if they are slower than the one before them, they will be push forward until the cannot be push anymore
    private void SortTurnActor(int NewestEntry){
        while ((NewestEntry>0)&&(TrackingActors[NewestEntry-1].ActorRolledSpeed>TrackingActors[NewestEntry].ActorRolledSpeed)){
            
                ActorTracker TempAcSlot= TrackingActors[NewestEntry-1]; //temp slot to swap
                TrackingActors[NewestEntry-1]= TrackingActors[NewestEntry];
                TrackingActors[NewestEntry]= TempAcSlot;
                NewestEntry--;
    
        }

    }
    public void LoadInStagePara(){
        GameObject[] ExpectActorArrays=GameObject.FindGameObjectsWithTag("Actor");;
        foreach (GameObject curActor in ExpectActorArrays){
            ActiveControl inniTiativeRoller= curActor.GetComponent<ActiveControl>();
            int Innitrolled=inniTiativeRoller.RollInitiativeOnTurn();
            AddActor(curActor, Innitrolled);
        }
        LoadInStageWaittime();
    }
    public IEnumerator LoadInStageWaittime(){
        
        yield return new WaitForSeconds(5f);
        
    }

}
