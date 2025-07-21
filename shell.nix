{
  pkgs ? import <nixpkgs> { },
}:

pkgs.mkShell {
  name = "bannerlord-mod-env";

  buildInputs = with pkgs; [
    mono
    # msbuild
    dotnet-sdk_9
    git
  ];

  shellHook = ''
    export BANNERLORD_GAME_DIR="$HOME/.steam/steam/steamapps/common/Mount & Blade II Bannerlord"
    echo "🔧 Bannerlord modding shell ready. Game dir: $BANNERLORD_GAME_DIR"
  '';
}
