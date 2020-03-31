using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float speed = 30f;
    [Tooltip("In ms")] [SerializeField] float xRange = 20f;

    [Tooltip("In ms")] [SerializeField] float yMin = -10f;
    [Tooltip("In ms")] [SerializeField] float yMax = 10f;

    float xThrow, yThrow;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f; 

    [SerializeField] float positionYawFactor = 2f;

    [SerializeField] float controlRollFactor = -15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessTranslation()
    {
        // X movement
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        // Y movement
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, yMin, yMax);

        // Apply movement
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        // Pitch +
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        // Yaw +
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        // Roll
        float rollDueToControlThrow = xThrow * controlRollFactor;
        float roll = rollDueToControlThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
