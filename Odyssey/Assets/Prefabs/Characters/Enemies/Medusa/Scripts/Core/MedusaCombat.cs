using UnityEngine;

public class MedusaCombat : MonoBehaviour
{
    MedusaController controller;

    //attacks enum and shared variables
    public int attackType;
    float attackRange = 6.5f;
    public float attackTimer;
    float timerAttack;
    float distance;
    
    float timerMove;
    //shard attack variables
    [SerializeField]MedusaShardAttack shardAttack = null;

    //projectile variables
    [SerializeField] Transform attack2Projectile;
    [SerializeField] Transform attack3Projectile;
    [SerializeField] Transform attack4PowerDraw;
    [SerializeField] Transform attack4PowerBeam;
    [SerializeField] Transform specialAttack1;
    //origin points
    [SerializeField] GameObject attack2Origin;
    [SerializeField] GameObject attack3Origin;
    [SerializeField] GameObject beamOrigin;
    [SerializeField] GameObject shieldOrigin;
    Transform bomb;
    Transform powerCharge;
    Transform aimspot;
    //bools
    bool rotateAim;
    public float rotationSpeed;
    public bool canShardAttack;
    
   
    

    private void Start()
    {
        controller = GetComponent<MedusaController>();
        timerAttack = attackTimer;
        aimspot = controller.player.GetComponent<PlayerController>().aimspot;
    }

    private void Update()
    {
        distance = Vector3.Distance(controller.player.position, transform.position);

        if (attackType == 1)
            ShardAttack();
        if (attackType == 2)
            Attack2Projectile();
        if (attackType == 3)
            Attack3Projectile();
        if (attackType == 4)
            Attack4Beam();
        if (attackType == 5)
            SpecialAttack1();


    }

    private void FixedUpdate()
    {
        if (rotateAim)
        {
            controller.movement.LookAtTarget(2f);
            
        }
    }

    private void ShardAttack()
    {
        

        if (distance <= attackRange && !canShardAttack)
        {
            controller.movement.canMove = false;
            rotateAim = true;
        }
        else if(canShardAttack)
        {
            shardAttack.attack = true;
            canShardAttack = false;
        }
        else
            controller.movement.canMove = true;

    }

    private void Attack2Projectile()
    {
        if (distance <= 12f && timerAttack <= 0)
        {
            controller.animatorController.animator.SetTrigger("attack2");
        }
        else
        {
            timerAttack -= Time.deltaTime;
        }
    }

    private void Attack3Projectile()
    {
        if (distance <= 20f)
        {
            attackType = 0;
            controller.animatorController.animator.SetTrigger("attack3");
        }
    }

    private void Attack4Beam()
    {
        if (distance < 12)
        {
            attackType = 0;
            controller.animatorController.animator.SetTrigger("attack4");
            controller.movement.canMove = false;
        }
    }

    private void SpecialAttack1()
    {
        if (distance < 5)
        {
            controller.animatorController.animator.SetTrigger("specialAttack1");
            controller.movement.canMove = false;
            attackType = 0;
        }
    }

    public void Attack2Event()
    {
        Transform projectile_transform = Instantiate(attack2Projectile, attack2Origin.transform.position, Quaternion.identity);
        Vector3 shootDirection = (aimspot.position - attack2Origin.transform.position).normalized;
        projectile_transform.GetComponent<ProjectileMedusa>().Setup(shootDirection, attack2Origin.transform.position, this.gameObject);
        timerAttack = 0.25f;
    }

    //attack 3 projectile charge up
    public void Charge()
    {
        
        controller.movement.canMove = false;
        controller.animatorController.animator.enabled = false;
        bomb = Instantiate(attack3Projectile, attack3Origin.transform.position, Quaternion.identity);
        Vector3 shootDirection = (aimspot.position - attack3Origin.transform.position).normalized;
        bomb.GetComponent<BombMedusa>().Setup(shootDirection, attack3Origin.transform.position, this.gameObject, attack3Origin, controller.player.transform);
        timerAttack = 0.25f;
    }

    //attack 3 projectile launch
    public void Shoot()
    {
        controller.movement.canMove = true;
        bomb.transform.SetParent(null);
        
    }

    //shoot beam
    public void Beam()
    {
        controller.animatorController.animator.enabled = false;
        Transform beam_transform = Instantiate(attack4PowerBeam, beamOrigin.transform.position, beamOrigin.transform.localRotation);
        beam_transform.SetParent(beamOrigin.transform);
        transform.position = new Vector3(transform.position.x, -0.31f, transform.position.z);
        rotateAim = true;
    }

    public void ShieldCharge()
    {
        Transform shieldBlastObject = Instantiate(specialAttack1, shieldOrigin.transform.position, Quaternion.identity);
        controller.animatorController.animator.enabled = false;
        shieldBlastObject.GetComponent<ShieldBlast>().controller = controller;
    }

    
}
