using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private Transform pressToRebindKeyTransform;

    private void Awake()
    {
        Instance = this;

        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateSoundEffectsTextVisual();
        });

        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateMusicTextVisual();
        });

        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });

        moveUpButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Up);
        });

        moveDownButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Down);
        });

        moveLeftButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Left);
        });

        moveRightButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Right);
        });

        interactButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Interact);
        });

        interactAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.InteractAlternate);
        });

        pauseButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Pause);
        });
    }

    private void Start()
    {
        GameManager.Instance.OnGameUnpaused += GameManager_OnGamePaused;
        UpdateAllTextVisuals();
        Hide();
        HidePressToRebindKey();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowPressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }

    public void HidePressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void UpdateAllTextVisuals()
    {
        UpdateSoundEffectsTextVisual();
        UpdateMusicTextVisual();
        UpdateMoveUpTextVisual();
        UpdateMoveDownTextVisual();
        UpdateMoveLeftTextVisual();
        UpdateMoveRightTextVisual();
        UpdateInteractTextVisual();
        UpdateInteractAlternateTextVisual();
        UpdatePauseTextVisual();
    }

    private void UpdateSelectedTextVisuals(GameInput.Binding binding)
    {
        switch (binding)
        {
            default:
            case GameInput.Binding.Move_Up:
                UpdateMoveUpTextVisual();
                break;
            case GameInput.Binding.Move_Down:
                UpdateMoveDownTextVisual();
                break;
            case GameInput.Binding.Move_Left:
                UpdateMoveLeftTextVisual();
                break;
            case GameInput.Binding.Move_Right:
                UpdateMoveRightTextVisual();
                break;
            case GameInput.Binding.Interact:
                UpdateInteractTextVisual();
                break;
            case GameInput.Binding.InteractAlternate:
                UpdateInteractAlternateTextVisual();
                break;
            case GameInput.Binding.Pause:
                UpdatePauseTextVisual();
                break;
        }
    }

    private void UpdateSoundEffectsTextVisual()
    {
        soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
    }

    private void UpdateMusicTextVisual()
    {
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);
    }

    private void UpdateMoveUpTextVisual()
    {
        moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
    }

    private void UpdateMoveDownTextVisual()
    {
        moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
    }

    private void UpdateMoveLeftTextVisual()
    {
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
    }

    private void UpdateMoveRightTextVisual()
    {
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
    }

    private void UpdateInteractTextVisual()
    {
        interactText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
    }

    private void UpdateInteractAlternateTextVisual()
    {
        interactAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
    }

    private void UpdatePauseTextVisual()
    {
        pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
    }

    private void RebindBinding(GameInput.Binding binding)
    {
        ShowPressToRebindKey();
        GameInput.Instance.RebindBinding(binding,() => {
            HidePressToRebindKey();
            UpdateSelectedTextVisuals(binding);
        });
    }
}
