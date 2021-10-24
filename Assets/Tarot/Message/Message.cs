using TMPro;
using UnityEngine;

public class Message: MonoBehaviour {
    // -- module --
    /// get the module
    public static Message Get {
        get => FindObjectOfType<Message>();
    }

    // -- config --
    [Header("config")]
    [Tooltip("the root transform")]
    [SerializeField] Transform m_Root;

    [Tooltip("the message text label")]
    [SerializeField] TMP_Text m_Text;

    // -- tuning --
    [Header("tuning")]
    [Tooltip("the height at which the text begins to fade out")]
    [SerializeField] float m_FallHeight = 7.5f;

    [Tooltip("the height at which the text fades out completely")]
    [SerializeField] float m_FadeEnd = 0.15f;

    [Tooltip("the height at which the text begins to fade out")]
    [SerializeField] float m_FadeStart = 1.15f;

    // -- lifecycle --
    void Start() {
        StartFall();
    }

    void FixedUpdate() {
        // fade out the text
        m_Text.alpha = Mathf.InverseLerp(m_FadeEnd, m_FadeStart, m_Root.position.y);
    }

    // -- commands --
    public void Show(string msg) {
        StartFall();
        m_Text.text = msg;
    }

    /// moves the message to the fall height
    void StartFall() {
        var p = m_Root.position;
        p.y = m_FallHeight;
        m_Root.position = p;
    }
}
