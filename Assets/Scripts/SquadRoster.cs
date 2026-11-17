using UnityEngine;
using System.Collections.Generic;

[System.Serializable] public class SquadMember { public string playerId; public string displayName; public int teamSlot; public bool isReady; }
public class SquadRoster : MonoBehaviour
{
    public int maxSquadSize = 4; public List<SquadMember> members = new List<SquadMember>();
    public bool AddMember(SquadMember member) { if (member == null || members.Count >= maxSquadSize || members.Exists(m => m.playerId == member.playerId)) return false; members.Add(member); return true; }
    public void RemoveMember(string playerId) { members.RemoveAll(m => m.playerId == playerId); }
}
