
public delegate KMS_Monster SpawnCallBack();

public class KMS_ProtoTypePattern
{
    SpawnCallBack spawnCallBack = null;

    // 처음 생성자로 생성할 때 어떤 함수가 호출될지를 저장
    public KMS_ProtoTypePattern(SpawnCallBack callBack)
    {
        spawnCallBack = new SpawnCallBack(callBack);
    }

    public KMS_Monster SpawnMonster()
    {
        // 생성자때 입력한 함수 호출
        return spawnCallBack();
    }
}