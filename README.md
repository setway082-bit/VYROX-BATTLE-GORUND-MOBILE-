# ELITE BATTLEGROUND — Unity 3D Battle Royale Starter

A Unity 2022.3 LTS C# starter for an original third-person battle-royale game. It is **not** a finished PUBG clone and does not include PUBG assets, maps, sounds, servers, or proprietary code.

## Included gameplay code
- Third-person CharacterController movement, sprint, jump, crouch and camera follow
- Hitscan weapon firing, ammo/reload and basic health/damage
- Shrinking safe zone with damage outside the zone
- Loot pickup and a small inventory data model
- Match phase/countdown scaffold and parachute descent controller
- Squad roster data model, cosmetic loadout data, and a vehicle seat/drive scaffold

## Quick setup
1. Install Unity Hub and Unity **2022.3 LTS** (3D Core project).
2. Create a project named `ELITE-BATTLEGROUND`.
3. Copy this package's `Assets/Scripts` folder into the project's `Assets` folder.
4. Create a ground Plane, add a Player object with `CharacterController`, `PlayerHealth`, `ThirdPersonMotor`, and `ThirdPersonCamera`.
5. Create a child Camera and assign it to `ThirdPersonCamera`. Assign the Player transform as target.
6. Add `SafeZoneController` to an empty object and set its center/radius. Add `SafeZoneDamage` to each player and assign the zone + health.
7. Add `WeaponController` to a weapon object; assign a camera and muzzle transform. Set a layer mask that excludes the player.
8. Add `LootPickup` to loot prefabs with a trigger collider and assign the item data.
9. Add `ParachuteController` to the player and call `BeginDrop()` from your spawn flow.
10. Read `Docs/ONLINE_SERVICES.md` before attempting online multiplayer or voice chat.

## Important
The scripts are starter systems, not a complete commercial game. You still need character/weapon/vehicle/map assets, animations, UI, audio, optimization, testing, anti-cheat, matchmaking, authoritative dedicated servers, and platform builds. A 100-player online match requires server architecture and load testing; it cannot be achieved by simply uploading these scripts to GitHub.
