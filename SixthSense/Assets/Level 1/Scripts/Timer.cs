// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // using UnityEngine.UI;
// // using TMPro;

// // public class Timer : MonoBehaviour
// // {
// //     [SerializeField] private Image uiFill;
// //     [SerializeField] private TextMeshProUGUI uiText;
// //     public int Duration;
// //     private int remainingDuration;
    
// //     private void Start ()
// //     {
// //         Being(Duration);
// //     }
    
// //     private void Being(int Second)
// //     {
// //         remainingDuration = Second;
// //         StartCoroutine(UpdateTimer());
// //     }

// //     private IEnumerator UpdateTimer()
// //     {
// //         while(remainingDuration >=0)
// //         {
// //             uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
// //             uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
// //             remainingDuration--;
// //             Debug.Log("Inside UpdateTimer: " + remainingDuration);
// //             yield return new WaitForSeconds(1f);
// //         }
// //         OnEnd();
// //     }

// //     private void OnEnd()
// //     {
// //         print("End");
// //         gameObject.GetComponent<PanelSwitcher>().switchpanel();
// //     }

// //     public void reduceTime()
// //     {
// //         remainingDuration -= 5;
// //         Debug.Log("Inside ReduceTime: " + remainingDuration);
// //         uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
// //         uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
// //         remainingDuration--;
// //         // StopCoroutine(UpdateTimer());
// //         // Being(remainingDuration);
// //     }

// // }


// using UnityEngine ;
// using UnityEngine.UI ;
// using UnityEngine.Events ;
// using System.Collections ;
// using TMPro;

// public class Timer : MonoBehaviour {
// //    [Header ("Timer UI references :")]
//    [SerializeField] private Image uiFillImage ;
//    [SerializeField] private TextMeshProUGUI uiText ;

//    public int Duration;

//    public bool IsPaused { get; private set; }

//    private int remainingDuration ;

//    // Events --
//    private UnityAction onTimerBeginAction ;
//    private UnityAction<int> onTimerChangeAction ;
//    private UnityAction onTimerEndAction ;
//    private UnityAction<bool> onTimerPauseAction ;

//    private void Start(){
//     SetDuration(60);
//     Begin();
//    }
   
//    private void Awake () {
//       ResetTimer () ;
//    }

//    private void ResetTimer () {
//       uiText.text = "00:00" ;
//       uiFillImage.fillAmount = 0f ;

//       Duration = remainingDuration = 0 ;

//       onTimerBeginAction = null ;
//       onTimerChangeAction = null ;
//       onTimerEndAction = null ;
//       onTimerPauseAction = null ;

//       IsPaused = false ;
//    }

//    public void SetPaused (bool paused) {
//       IsPaused = paused ;

//       if (onTimerPauseAction != null)
//          onTimerPauseAction.Invoke (IsPaused) ;
//    }


//    public Timer SetDuration (int seconds) {
//       Duration = remainingDuration = seconds ;
//       return this ;
//    }

// //    -- Events ----------------------------------
//    public Timer OnBegin (UnityAction action) {
//       onTimerBeginAction = action ;
//       return this ;
//    }

//    public Timer OnChange (UnityAction<int> action) {
//       onTimerChangeAction = action ;
//       return this ;
//    }

//    public Timer OnEnd (UnityAction action) {
//       onTimerEndAction = action ;
//       return this ;
//    }

//    public Timer OnPause (UnityAction<bool> action) {
//       onTimerPauseAction = action ;
//       return this ;
//    }


//     public void reduceTime()
//     {
//         remainingDuration -= 5;
//         Debug.Log("ReduceTime: "+ remainingDuration);
//         StopAllCoroutines () ;
//         StartCoroutine (UpdateTimer ()) ;
//     }


//    public void Begin () {
//       if (onTimerBeginAction != null)
//          onTimerBeginAction.Invoke () ;
//       StopAllCoroutines () ;
//       StartCoroutine (UpdateTimer ()) ;
//    }

//    private IEnumerator UpdateTimer () {
//       while (remainingDuration > 0) {
//          if (!IsPaused) {
//             if (onTimerChangeAction != null)
//                onTimerChangeAction.Invoke (remainingDuration);

//             UpdateUI (remainingDuration) ;
//             remainingDuration-- ;
//             Debug.Log("UpdateTimer: "+ remainingDuration);
//          }
//          yield return new WaitForSeconds (1f) ;
//       }
//       End () ;
//    }

//    private void UpdateUI (int seconds) {
//       uiText.text = string.Format ("{0:D2}:{1:D2}", seconds / 60, seconds % 60) ;
//       uiFillImage.fillAmount = Mathf.InverseLerp (0, Duration, seconds) ;
//    }

//    public void End () {
//       if (onTimerEndAction != null)
//          onTimerEndAction.Invoke () ;

//       ResetTimer () ;
//    }


//    private void OnDestroy () {
//       StopAllCoroutines () ;
//    }
// }