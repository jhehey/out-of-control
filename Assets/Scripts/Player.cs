using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class Player : BaseEntity
    {
        public GameObject currentProjectile { get; set; }
        public float moveSpeed { get; set; } = 500f;

        public void Move(Vector2 to, float speed)
        {
            rb.velocity = to * speed * Time.fixedDeltaTime;
        }

        #region Singleton
        private static Player instance;
        public static Player Instance { get => instance; }
        private void CreateInstance()
        {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
            }
        }
		#endregion

		#region Private
		private Rigidbody2D rb { get; set; }
        private Vector2 moveDirection { get; set; }
        private void Awake()
        {
            CreateInstance();

            rb = rb ?? GetComponent<Rigidbody2D>();

            currentProjectile = Prefabs.Instance.BasicBulletProjectile;

            StartCoroutine(ShootProjectile(400f));
            StartCoroutine(RandomizeMovement());
        }

        private IEnumerator ShootProjectile(float msInterval)
        {
            while (true)
            {
                Debug.Log("ShootProjectile");

                // compute direction
                Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
                Vector2 direction = difference / difference.magnitude;
                float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                // spawn at current position
                GameObject newProjectile = Instantiate(currentProjectile, this.transform);
                newProjectile.transform.position = this.transform.position;
                newProjectile.transform.rotation = rotation;

                Projectile projectile = newProjectile.GetComponent<Projectile>();
                projectile.Shoot(this.gameObject, direction);

                yield return new WaitForSeconds(msInterval / 1000f);
            }
        }

        private IEnumerator RandomizeMovement()
        {
            while (true)
            {
                float randomAngle = Random.Range(0, 360) * Mathf.PI / 180f;
                moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
                yield return new WaitForSeconds(Random.Range(0.5f, 3f));
            }
        }

        private void Update()
        {
            Move(moveDirection, moveSpeed);
        }

        #endregion

    }

}