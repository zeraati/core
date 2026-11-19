# Coding Style

- Prefer compact, single-line declarations when they remain readable.
- Avoid wrapping short method signatures, parameter lists, and simple expressions across multiple lines.
- Do not use the `Async` suffix in asynchronous method names.
- Keep the number of methods per file reasonably low.
- If a file remains large, group related functionality by responsibility into a small number of files.

# Documentation Guidelines

- Write all documentation in Persian, keeping technical terms in English.
- After each task, update affected documentation when changes impact behavior, architecture, business rules, or documented functionality.
- Keep `README.md` concise, covering project overview, setup, structure, technologies, and documentation links.
- Organize documentation by module or feature, avoiding unnecessary files for individual classes or methods.
- Document important modules, classes, dependencies, responsibilities, business rules, and non-obvious logic.
- Maintain relevant architecture, database, API, and module documentation. Use Mermaid diagrams when they improve understanding.
- Record meaningful changes in `/Docs/changelog.md` and significant architectural decisions with their rationale.
