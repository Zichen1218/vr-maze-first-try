using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class moveramp : MonoBehaviour
{
    public GameObject Ramp; // 在Unity编辑器中指定Ramp对象
    public XRBaseController headController;
    private bool isActive = false;
    private Vector3 offset;

    private void OnCollisionEnter(Collision collision)
    {
        // 检查发生碰撞的对象是否是球
        if (collision.gameObject.name == "mesh0")
        {
            offset = Ramp.transform.position - new Vector3(headController.transform.position.x, Ramp.transform.position.y, headController.transform.position.z);
            StartCoroutine(MoveRampUpDown()); // 开始协程来移动Ramp
        }
    }
    private void Update()
    {
        if (isActive)
        {
            // 更新Ramp的x和z坐标以匹配headController的位置，y坐标保持当前值
            Ramp.transform.position = new Vector3(headController.transform.position.x+offset.x, Ramp.transform.position.y, headController.transform.position.z + offset.z);
        }
    }

    IEnumerator MoveRampUpDown()
    {
         isActive = true;
        // 下降阶段
        yield return StartCoroutine(MoveRamp(-5.0f, 2.0f));  // 下降5单位，耗时2秒

        // 停留阶段
        yield return new WaitForSeconds(5.0f);  // 停留5秒

        // 回升阶段
        yield return StartCoroutine(MoveRamp(5.0f, 2.0f));  // 回升5单位，耗时2秒
        isActive = false;
    }

    IEnumerator MoveRamp(float moveDistance, float duration)
    {
        float startHeight = Ramp.transform.position.y;
        float endHeight = startHeight + moveDistance; 
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            // 计算Ramp当前的位置
            float newY = Mathf.Lerp(startHeight, endHeight, elapsedTime / duration);
            Ramp.transform.position = new Vector3(Ramp.transform.position.x, newY, Ramp.transform.position.z);

            // 更新经过的时间
            elapsedTime += Time.deltaTime;

            // 等待下一帧
            yield return null;
        }

        // 确保Ramp最终到达目标高度
        Ramp.transform.position = new Vector3(Ramp.transform.position.x, endHeight, Ramp.transform.position.z);
    }
}

