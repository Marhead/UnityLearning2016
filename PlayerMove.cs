float speed = 3f;
void Move(Vector2 direction)
{
Vector2 pos = transform.position;
pos += direction * Time.deltaTime;
transform.position = pos;
}
// Update is called once per frame
void Update () {

    Vector3 Dir = Vector3.zero;

    if (Input.GetKey(KeyCode.LeftArrow))
        Dir.x = -1f;
    if (Input.GetKey(KeyCode.RightArrow))
        Dir.x = +1f;
    if (Input.GetKey(KeyCode.UpArrow))
        Dir.y = +1f;
    if (Input.GetKey(KeyCode.DownArrow))
        Dir.y = -1f;

    float Dist = Mathf.Sqrt((Dir.x * Dir.x) + (Dir.y * Dir.y));
    Dir.x /= Dist;
    Dir.y /= Dist;

    if(Dist == 0)
        return;

    transform.position += Dir * Time.deltaTime * 5f;
}