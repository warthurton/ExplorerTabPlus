# Agent instructions

## Keep the README current (required)

`README.md` documents what this fork contains and where each piece came from. Whenever you add, merge, remove or change a feature, fix or maintenance item, update documentation in the same change:

1. `README.md`
   - "What's new compared with upstream" table (one row per merged upstream PR, with PR link and author).
   - "Layers of this fork" table (source repo/fork → what it contributed). Add a row or extend an existing one when cherry-picking or merging from another fork.
   - "Features" section for user-visible behavior, marking new items and naming the source.
   - "Credits" for every new source repository or contributor.
   - Hotkey actions table / Usage / Build sections if they are affected.
2. `.github/release-notes/v<version>.md` — add the entry (with "from <source>" attribution) under Added / Fixed / Changed.
3. Translated READMEs (`docs/README.zh-CN.md`, `docs/README.zh-TW.md`, `docs/README.ja.md`) — the maintainer doesn't read these languages, so they are not kept in sync. Leave the "not up to date, see English README" note at the top of each in place and don't mirror changes.

Always attribute the origin (repository, PR number, author) of merged work, and preserve original authors' commits when merging.

## Build notes

Build with full-framework MSBuild, not `dotnet build` (COM references); see "Build from source" in the README.
