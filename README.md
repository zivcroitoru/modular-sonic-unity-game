# 🌀 Work-in-Progress Sonic-Style Game

[![Watch the demo](https://img.youtube.com/vi/-EWJJSfTjs0/hqdefault.jpg)](https://youtu.be/-EWJJSfTjs0)

A high-speed 2D Sonic platformer built in Unity using professional software engineering practices:
**SOLID design**, **async gameplay systems**, **editor extensions**, **object pooling**, and powerful **architecture patterns**.

---

## 🧩 Architecture Overview

### ✅ **SOLID Principles**

* **Single Responsibility**: Each class handles one task only (e.g., `PlayerMovement`, `PlayerJump`)
* **Open/Closed**: Easily extend pickups, enemies, or terrain features without modifying core logic
* **Interface Segregation & Liskov**: Components like `IPickup`, `IDamageable` are used to decouple logic
* **Dependency Inversion**: Core systems injected into consumers for testability and modularity

---

## ⚙️ Key Features & Patterns

### 🎮 **Gameplay Systems**

* **Modular Pickups** (`IPickup`) – coins, power-ups

### 🧵 **Async & Tasks**


### 🛠 **Editor Scripts & Extensions**

* Custom `PrefabSpawnerWindow` for drag-and-drop coin placement
* Level validator: checks spawn points, hazards, and collectibles
* `Gizmos` and debug overlays for hitboxes and sensors

---

## 🔁 Performance & Patterns

### 🧠 **Design Patterns Used**

* **Singletons** for global managers (e.g., `GameManager`)
* **Object Pooling** for rings, projectiles, enemies
* **Builder & Factory** for complex object construction (e.g., enemy spawns)

### 🧪 **Dependency Injection**

* Input handling, audio, UI, and data are injected into systems using interface-based DI
* Facilitates clean testing and scene reusability

