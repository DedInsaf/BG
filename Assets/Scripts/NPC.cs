using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
   public Transform patrolRoute;
   public List<Transform> locations;

   private int locationIndex = 0;
   private NavMeshAgent agent;

   void Start()
   {
      agent = GetComponent<NavMeshAgent>();
      
      InitializePatrolRoute();
      MoveToNextPatrolLocation();
   }

   void Update()
   {
      if (agent.remainingDistance < 0.2f && !agent.pathPending)
      {
         MoveToNextPatrolLocation();
      }
   }

   void InitializePatrolRoute()
   {
      foreach(Transform child in patrolRoute)
      {
         locations.Add(child);
      }
   }

   void MoveToNextPatrolLocation()
   {
      if (locations.Count == 0)
         return;
      agent.destination = locations[locationIndex].position;
      locationIndex = (locationIndex + 1) % locations.Count;
   }
}
