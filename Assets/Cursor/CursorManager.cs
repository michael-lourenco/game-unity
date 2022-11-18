using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// video base : https://www.youtube.com/watch?v=8Fm37H1Mwxw
public class CursorManager : MonoBehaviour
{

    public static CursorManager Instance { get; private set;}
    public event EventHandler<OnCursorChangedEventArgs> OnCursorChanged;

    public class OnCursorChangedEventArgs: EventArgs {
        public CursorType cursorType;
    }

    [SerializeField] private int frameCount;
    [SerializeField] private float frameRate;

    [SerializeField] private List<CursorAnimation> cursorAnimatonList;

    private CursorAnimation cursorAnimation;
    private int currentFrame;
    private float frameTimer;

    public enum CursorType
    {
        Basic,
        Attack
    }

    private void Awake() {
        Instance = this;
    }

    void Start()
    {
        SetActiveCursorType(CursorType.Basic);
    }

    // Update is called once per frame
    private void Update()
    {
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0f)
        {
            frameTimer += frameRate;
            currentFrame = (currentFrame + 1) % frameCount;
            Cursor.SetCursor(cursorAnimation.textureArray[currentFrame], cursorAnimation.offset, CursorMode.Auto);
        }

    }

    public void SetActiveCursorType(CursorType cursorType){
        SetActiveCursorAnimation(GetCursorAnimation(cursorType));

        // Esta parte está no final do video para poder selecionar atraves do arrastar do mouse. Não implementei
        OnCursorChanged?.Invoke(this, new OnCursorChangedEventArgs { cursorType = cursorType});
    }
    private CursorAnimation GetCursorAnimation(CursorType cursorType) {
        foreach(CursorAnimation cursorAnimation in cursorAnimatonList) {
            if(cursorAnimation.cursorType == cursorType) {
                return cursorAnimation;
            }
        }
        // Couldn't find this CursorType!
        return null;
    }
    private void SetActiveCursorAnimation(CursorAnimation cursorAnimation) {
        this.cursorAnimation = cursorAnimation;
        currentFrame = 0;
        frameTimer = cursorAnimation.frameRate;
        frameCount = cursorAnimation.textureArray.Length;
    }
    [System.Serializable]
    public class CursorAnimation
    {
        public CursorType cursorType;
        public Texture2D[] textureArray;
        public float frameRate;
        public Vector2 offset;

    }
}
