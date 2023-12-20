using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private RectTransform message;
    [SerializeField] private CanvasGroup messageCanvasGroup;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private float messageAppearDuration;
    [SerializeField] private float letterAppearDelay;
    private int _currentMessageID;
    private DialogSO _currentDialogSO;
    private bool _isShowing;
    private IEnumerator dialog;
    private event UnityAction onCompleteDialog;
    private bool _isDialogEnded;
    private Tween disappearTween;
    public void ShowMessage(DialogSO dialogSO, int idMessage, UnityAction onComplete = null)
    {
        if (idMessage == 0)
        {
            _isDialogEnded = false;
            AppearMessage();
            onCompleteDialog = onComplete;
        }
        else if (idMessage == dialogSO.Text.Length)
        {
            _isDialogEnded= true;
            DisappearMessage();
            print("DialogCompleted");
            onCompleteDialog?.Invoke();
            return;
        }
        if (_isDialogEnded)
            return;
        _currentDialogSO = dialogSO;
        _currentMessageID = idMessage;
        dialog = ShowTextWithDelay(dialogSO.Text[idMessage], messageText);
        StartCoroutine(dialog);
    }
    private IEnumerator ShowTextWithDelay(string fullText, TMP_Text textComponent)
    {
        textComponent.text = "";
        _isShowing = true;
        for (int i = 0; i < fullText.Length; i++)
        {
            textComponent.text += fullText[i];
            yield return new WaitForSeconds(letterAppearDelay);
        }
        _isShowing = false;
    }
    private void AppearMessage()
    {
        disappearTween?.Kill();
        message.gameObject.SetActive(true);
        message.transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence();
        messageCanvasGroup.DOFade(1, messageAppearDuration/4);
        sequence.Append(message.DOAnchorPosY(50f, messageAppearDuration / 4 * 3).SetRelative());
        sequence.Append(message.DOAnchorPosY(-30f, messageAppearDuration / 4).SetRelative());
        sequence.Insert(0, message.transform.DOScale(Vector3.one, messageAppearDuration));
    }
    private void DisappearMessage()
    {
        disappearTween = messageCanvasGroup.DOFade(0, messageAppearDuration).OnKill(()=>message.gameObject.SetActive(false));
    }
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (_isShowing)
            {
                StopCoroutine(dialog);
                messageText.text = _currentDialogSO.Text[_currentMessageID];
                _isShowing = false;
                return;
            }
            else
            {
                ShowMessage(_currentDialogSO, ++_currentMessageID);
            }
        }
    }
}
