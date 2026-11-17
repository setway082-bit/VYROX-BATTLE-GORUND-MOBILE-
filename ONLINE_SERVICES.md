# Online multiplayer, squads and voice

The included `SquadRoster` is local gameplay data only. It does not connect players over the internet.

For real online play, choose and integrate one networking stack (for example Unity Netcode for GameObjects with a dedicated-server hosting solution, or a managed multiplayer service). Implement server-authoritative movement, weapon validation, hit detection, inventory, loot spawning, safe-zone state, match state, reconnects, matchmaking, lobby/party invites, latency handling and anti-cheat. Do not trust client-reported hits or inventory.

For voice, integrate a voice SDK such as Vivox or another supported provider. Create team channels, proximity channels, mute controls, push-to-talk, moderation and platform permission handling. Voice is not implemented by the local squad data class.

A sensible milestone order:
1. Offline greybox prototype with 2–4 test bots.
2. Two-client network test with server-authoritative movement and damage.
3. Lobby + squad invites + team voice.
4. Dedicated-server 8–16 player test.
5. Scale gradually; profile server CPU/network before targeting 100 players.
