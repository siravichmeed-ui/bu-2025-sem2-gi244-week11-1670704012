# SKILL: Unity Git Setup (agent-customization)

## Purpose

Provide a reusable, workspace-scoped skill that automates the common Git setup tasks for Unity projects: creating a correct `.gitignore`, optionally configuring Git LFS and `.gitattributes`, and running basic verification checks. Target audience: Unity3D developers familiar with C#.

## When to use

- New Unity repository initialization
- Converting a non-ignored Unity project to proper Git tracking
- Onboarding contributors who need a consistent repo layout

## Outcome

- Adds a canonical `.gitignore` tuned for Unity projects at the repository root.
- Optionally creates `.gitattributes` and tracks large binary types with Git LFS.
- Runs verification commands and returns a short checklist the user can commit.

## Step-by-step workflow (extracted & generalized)

1. Detect Unity project root (presence of `Assets/` and `ProjectSettings/`). If not found, ask the user for the intended root.
2. Create a standard `.gitignore` containing OS/IDE and Unity-generated patterns (Library/, Temp/, Obj/, Logs/, etc.).
3. Decision: Configure Git LFS?
   - If yes: create a recommended `.gitattributes` listing large binary extensions (e.g., `*.png filter=lfs diff=lfs merge=lfs -text`) and run `git lfs install` + `git lfs track` for selected patterns.
   - If no: skip LFS but document recommended extensions for later.
4. Verify ignores and LFS:
   - `git check-ignore -v <example-file>` to confirm expected files are ignored.
   - `git ls-files --others --exclude-standard` to list remaining untracked files.
5. Offer to stage and commit the created files with a clear commit message and optionally push.

## Decision points and branching logic

- Workspace vs personal settings: whether to add editor-specific settings (e.g., `.vscode/`) to `.gitignore` or keep some settings in source control.
- Git LFS: enable immediately or defer. If team already uses LFS, adding tracks is safe; if not, adding LFS tracking requires collaborators to install `git-lfs`.
- ProjectSettings: generally commit `ProjectSettings/` for reproducible editor settings, but check team conventions.

## Quality criteria / completion checks

- `.gitignore` exists at the repo root and contains the key Unity sections.
- `git check-ignore -v Assets/<file>` shows that known generated files are ignored.
- If LFS configured: `.gitattributes` present and `git lfs track` shows the tracked patterns.
- Suggested commit (staged files) is ready: `.gitignore` and optionally `.gitattributes`.

## Example prompts to invoke this skill

- "Add Unity .gitignore only" — creates `.gitignore` and runs verification.
- "Add Unity .gitignore and configure Git LFS for textures and models" — also creates `.gitattributes` and runs `git lfs track` for common extensions.
- "Check current repo for Unity ignore issues" — performs detection and verification only.

## Outputs produced by the skill

- Files created/updated: `.gitignore` (required), `.gitattributes` (optional).
- A short verification report with commands and next steps.
- Suggested `git` commands to run locally (staging, committing, pushing).

## Edge cases and notes

- Monorepos: locate the correct Unity project subfolder and apply ignore rules there instead of the repo root.
- Existing `.gitignore` entries: merge responsibly; do not overwrite without confirmation.
- Large binary history already present: adding LFS post-factum requires history rewrite to convert existing files — warn the user.

## Suggested next customizations

- `copilot-instructions.md` for Unity/C# coding style and common snippets.
- `.editorconfig` tuned for C# (tabs/spaces, newline rules).
- `AGENTS.md` or small `README.md` describing repo setup and required tools (`git-lfs`, Unity version).

## References

- Official community Unity `.gitignore` template: https://github.com/github/gitignore/blob/main/Unity.gitignore
- Git LFS docs: https://git-lfs.github.com/

## Questions for the user (ambiguities to resolve)

1. Should this skill be saved as workspace-scoped (checked into the repo) or be a personal helper outside the repository?
2. Do you want me to configure Git LFS automatically for common binary types (textures, models, large audio)?
3. Should I stage and commit the created files, or just create them and leave committing to you?

## Example quick run commands the skill will suggest

```bash
git add .gitignore
git add .gitattributes    # if created
git commit -m "chore: add Unity .gitignore (and Git LFS config)"
git push
```
