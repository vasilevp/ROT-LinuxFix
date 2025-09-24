# ROT-LinuxFix

Linux compatibility patch for **Realm of Thrones**, a popular Game of Thrones-inspired mod for *Mount & Blade II: Bannerlord*. This project resolves runtime issues and improves mod stability on Linux systems.

## Installation

1. Download the latest release or build from source.
2. Extract the contents to your Bannerlord `Modules` directory, typically found at:
   - Steam: `~/.steam/steam/steamapps/common/Mount & Blade II Bannerlord/Modules`
   - GOG: `~/GOG Games/Mount & Blade II Bannerlord/Modules`
3. Ensure the `Realm of Thrones` mod is loaded after this patch in the mod list.

## 🚀 Build Instructions

### Requirements

- Mount & Blade II: Bannerlord (installed via Steam or GOG)
- Realm of Thrones mod (latest version)
- .NET SDK (>= 6.0)
- Nix (optional, for reproducible builds)

### Build Steps

```bash
# Optional: enter reproducible dev shell
nix-shell

# Build the patch
dotnet build ROT-LinuxFix.csproj
