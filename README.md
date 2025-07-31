# 🎮 LOOP — GMTK 2025 Game Jam

**Genre**: Action Roguelike  
**Inspiration**: *Wizard of Legend*, *The Binding of Isaac*  
**Jam Duration**: 96 hours  
**Theme**: "Loop"

---

## 🧠 Concept

- When you die, you **restart at the beginning**, but:
  - Enemies get stronger  
  - You keep your upgraded gear  
- Your goal is to **beat Satan** at the end of the loop  
- Top-down magic-combat gameplay inspired by action roguelikes

---

## 🚀 Getting Started

Clone the repository and open it in Unity:

```bash
cd "C:\Your\Preferred\Folder"
git clone https://github.com/MakoJBryant/GMTK-2025-Game-Jam.git
```

Then:

1. Open **Unity Hub**
2. Click **"Open Project"**
3. Select the cloned folder

✅ Unity version: *6000.0.51f1*

---

## 📁 Folder Structure

```plaintext
Assets/
├── _LOOP/                       ← Main game content
│   ├── Art/                     ← Sprites, palettes, visual assets
│   │   ├── Sprites/
│   │   └── Palettes/
│   ├── Audio/                   ← SFX, music
│   ├── Prefabs/                 ← Reusable game objects
│   ├── Scenes/                  ← Main and test scenes
│   ├── Scripts/                 ← Organized by feature/system
│   │   ├── Player/
│   │   ├── Enemies/
│   │   ├── Systems/
│   │   └── UI/
│   ├── Settings/                ← Tilemaps, scene data, ScriptableObjects
│   └── Sandbox/YourName/        ← Dev work area for experiments
├── ThirdParty/                  ← 3rd-party assets (do not modify)
```

> 🔁 The `_LOOP/` folder is the core of our project — all team edits should go here.

---

## 👥 Team Workflow Guidelines

- **One scene per person** when testing features (use `/Sandbox/`).
- Use **Git regularly**, pull before pushing, and commit in small chunks.
- Keep naming consistent and clear (`PlayerMovement.cs`, `Fireball.prefab`, etc.)
- Clean up your **Sandbox/** work before the final push!

---

## 📌 Milestones

- [ ] Core movement + combat
- [ ] Enemies & loop progression
- [ ] Power-ups & gear system
- [ ] Final boss & ending sequence

---
