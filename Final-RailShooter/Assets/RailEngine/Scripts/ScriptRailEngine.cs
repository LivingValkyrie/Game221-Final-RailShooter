using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/*
 * @author Mike Dobson
 * modified by matt gipson
 * */
//[Serializable]
public class ScriptRailEngine : MonoBehaviour {

	public List<ScriptMovements> movements;
    public List<ScriptFacings> facings;
    public List<ScriptEffects> effects;

    public ScriptCameraShake cameraShakeScript;
    public ScriptLookAtTarget cameraLookAtScript;
    public ScriptLookAtTarget playerLookAtScript;
    public ScriptScreenFade fadeScript;
    public ScriptSplatter splatterScript;

    public void Awaken()
    {
        playerLookAtScript = this.gameObject.GetComponent<ScriptLookAtTarget>();
        cameraShakeScript = Camera.main.GetComponent<ScriptCameraShake>();
        cameraLookAtScript = Camera.main.GetComponent<ScriptLookAtTarget>();
        fadeScript = Camera.main.GetComponent<ScriptScreenFade>();
        splatterScript = Camera.main.GetComponent<ScriptSplatter>();
    }

	// Use this for initialization
	public void Starter () 
	{
        //Starts the Engine Coroutine
        StartCoroutine(MovementEngine());
        StartCoroutine(EffectsEngine());
        StartCoroutine(FacingEngine());
	}

	IEnumerator MovementEngine()
	{
		foreach(ScriptMovements move in movements)
		{
			
			switch(move.moveType)
			{
				case MovementTypes.STRAIGHT:
                    if (move.endWaypoint != null && move.movementTime > 0)
                    {
                        //Do the movement coroutine with the help of the movement script
                        StartCoroutine(movementMove(move.endWaypoint.transform.position, move.movementTime));

                        //Wait for the specified amount of time on the movement waypoint
                        yield return new WaitForSeconds(move.movementTime);
                    }
                    else
                    {
                        ScriptErrorLogging.logError("Movement was skipped due to missing element");
                    }
					break;
				case MovementTypes.WAIT:
                    if (move.movementTime > 0)
                    {
                        //Does the wait
                        StartCoroutine(movementWait(move.movementTime));

                        //Waits for the specified amount of time
                        yield return new WaitForSeconds(move.movementTime);
                    }
                    else
                    {
                        ScriptErrorLogging.logError("Wait was skipped due to missing element");
                    }
					break;
                case MovementTypes.BEZIER:
                    if (move.endWaypoint != null && move.curveWaypoint != null && move.movementTime > 0)
                    {
                        StartCoroutine(movementBezier(move.endWaypoint.transform.position, move.curveWaypoint.transform.position, move.movementTime));

                        //Waits for the specified amount of time to continue
                        yield return new WaitForSeconds(move.movementTime);
                    }
                    else
                    {
                        ScriptErrorLogging.logError("Movement was skipped due to missing element");
                    }
                    break;
				default:
					ScriptErrorLogging.logError ("Invalid movement type!");
					break;
					
			}
		}        
	}

    IEnumerator EffectsEngine()
    {
        foreach (ScriptEffects effect in effects)
        {
            switch (effect.effectType)
            {
                case EffectTypes.SPLATTER:
                    if (effect.imageScale == 0)
                    {
                        splatterScript.Activate(effect.effectTime, effect.fadeInTime, effect.fadeOutTime);
                    }
                    else if (effect.imageScale != 0)
                    {
                        splatterScript.Activate(effect.effectTime, effect.fadeInTime, effect.fadeOutTime, effect.imageScale);
                    }
                    else
                    {
                        splatterScript.Activate();
                    }
                    yield return new WaitForSeconds(effect.effectTime);
                    break;
                case EffectTypes.SHAKE:
                    if (effect.magnitude != 0)
                    {
                        cameraShakeScript.Activate(effect.effectTime, effect.magnitude);
                    }
                    else
                    {
                        cameraShakeScript.Activate();
                    }
                    yield return new WaitForSeconds(effect.effectTime);
                    break;
                case EffectTypes.FADE:                                     
					fadeScript.Activate(effect.effectTime, effect.fadeInTime, effect.fadeOutTime);                             
                    yield return new WaitForSeconds(effect.effectTime);
                    break;
                case EffectTypes.WAIT:
                    yield return new WaitForSeconds(effect.effectTime);
                    break;
                default:
                    break;

            }
        }
    }

    /// <summary>
    /// @Author Marshall Mason & Mike Dobson
    /// </summary>
    IEnumerator FacingEngine()
    {
        ScriptLookAtTarget lookScript = Camera.main.GetComponent<ScriptLookAtTarget>();
        foreach (ScriptFacings facing in facings)
        {
            //Debug.Log(facing);
            switch (facing.facingType)
            {
                case FacingTypes.LOOKAT:
                    //Do the facing action
                    if(facing.cameraMoveOnly)
                    {
                        cameraLookAtScript.Activate(facing.rotationSpeed, facing.targets, facing.lockTimes);
                    }
                    else
                    {
                        playerLookAtScript.Activate(facing.rotationSpeed, facing.targets, facing.lockTimes);
                    }
                        //Wait for the specified amount of time on the facing waypoint
                        yield return new WaitForSeconds(facing.rotationSpeed[0] + facing.rotationSpeed[1] + facing.lockTimes[0]);
                    
                    break;
                case FacingTypes.WAIT:
                    
                        //Waits for the specified amount of time
                        yield return new WaitForSeconds(facing.facingTime);
                    
                    break;
                case FacingTypes.LOOKCHAIN:

                    //Do the facing action
                    if(facing.cameraMoveOnly)
                    {
                        cameraLookAtScript.Activate(facing.rotationSpeed, facing.targets, facing.lockTimes);
                    }
                    else
                    {
                        playerLookAtScript.Activate(facing.rotationSpeed, facing.targets, facing.lockTimes);
                    }

                        //Wait for the specified amount of time on the facing waypoint
                        float waitTime = 0;
                        for (int i = 0; i < facing.targets.Length; i++)
                        {
                            waitTime += facing.rotationSpeed[i];
                            waitTime += facing.lockTimes[i];
                        }
                        waitTime += facing.rotationSpeed[facing.rotationSpeed.Length - 1];
                        yield return new WaitForSeconds(waitTime);
                    
                    break;
                case FacingTypes.FREELOOK:

                    cameraLookAtScript.StartCoroutine( "FreeLook", facing.facingTime );

                    yield return new WaitForSeconds( facing.facingTime );

                    break;
                default:
                    ScriptErrorLogging.logError("Invalid movement type!");
                    break;
            }
        }
    }

	IEnumerator movementMove(Vector3 target, float time)
	{
		//Tracking the elapsed time
		float elapsedTime = 0;

		//Store the starting position of the object
		Vector3 startPos = transform.position;

		//Continue while we are still below required time
		while(elapsedTime < time)
		{
			//start position, end position, time
			transform.position = Vector3.Lerp(startPos,
			                                  target,
			                                  (elapsedTime/time));
			elapsedTime += Time.deltaTime;

			//Wait to be called again by the game loop
			yield return null;
		}

		//Snap the player to target position at end of lerp
		transform.position = target;
	}

	IEnumerator movementWait(float time)
	{
		ScriptErrorLogging.logError ("starting wait");
		yield return new WaitForSeconds (time);
		ScriptErrorLogging.logError ("next waypoint");
	}

    //@reference Tiffany Fisher
    IEnumerator movementBezier(Vector3 target, Vector3 curve, float time)
    {
        //Get the current time
        float startTime = Time.time;
        //find the time for the end of the movement
        float endTime = startTime + time;

        //get the start of the curve
        Vector3 startCurve = transform.position;
        //elapsed time 
        float elapsedTime = 0f;

        //While time is lest than the end time
        while(Time.time < endTime )
        {
            
            //track the current elapsed time after each frame
            elapsedTime += Time.deltaTime;
            float curTime = elapsedTime / time;

            //move along the curve
            transform.position = GetPoint(startCurve, target, curve, curTime);
            yield return null;
        }

        //Snap the player to the target position at the end of the curve
        transform.position = target;
        
    }

    public Vector3 GetPoint(Vector3 start, Vector3 end, Vector3 curve, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * start + 2f * oneMinusT * t * curve + t * t * end;
    }

    void OnDrawGizmos()
    {
        GameObject start = GameObject.FindGameObjectWithTag("Start");
        Vector3 lineStarting = start.transform.position;
        
        foreach(ScriptMovements move in movements)
        {
            switch(move.moveType)
            {
                case MovementTypes.STRAIGHT:
                    if (move.endWaypoint != null && move.movementTime > 0)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawLine(lineStarting, move.endWaypoint.transform.position);
                        lineStarting = move.endWaypoint.transform.position;
                    }
                    else
                    {
                        //Debug.Log("Missing Element in " + move.moveType + " waypoint");
                    }
                    break;
                case MovementTypes.WAIT:
                    if (move.movementTime > 0)
                    {
                        Gizmos.color = Color.yellow;
                        Gizmos.DrawWireSphere(lineStarting, 1f);
                    }
                    else
                    {
                        //Debug.Log("Missing Element in " + move.moveType + " waypoint");
                    }
                    break;
                case MovementTypes.BEZIER:
                    if (move.endWaypoint != null && move.curveWaypoint != null && move.movementTime > 0)
                    {
                        Gizmos.color = Color.green;
                        Vector3 bezierStart = lineStarting;
                        //@reference Tiffany Fisher
                        for (int i = 1; i <= 10; i++)
                        {
                            Vector3 lineEnd = GetPoint(bezierStart, move.endWaypoint.transform.position, move.curveWaypoint.transform.position, i / 10f);
                            Gizmos.DrawLine(lineStarting, lineEnd);
                            lineStarting = lineEnd;
                        }
                    }
                    else
                    {
                        //Debug.Log("Missing Element in " + move.moveType + " waypoint");

                    }
                    break;
                default:
                    break;
            }
        }

    }


}
