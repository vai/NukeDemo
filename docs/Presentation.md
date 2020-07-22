# Declarative Builds
_Beyond commit-based debugging_

---

## Continuous Integration

---

#### Hosted CI systems are good

**Performant**
- Near to changes, provider scaled

**Reliable**
- Cheaper, more stable than self-hosted

**Extendable**
- SaaS Integrations can multiply CI value


---

#### Declarative builds are good

**Self documenting**
- Embedded build definitions allow build processes to be versioned

**Consistent**
- Deterministic builds provide strong guarantees about your outputs

**Verifiable**
- Each commit’s build output should be an exact match


---

## But, ...

---

## YAML.

---

#### YAML* is ...

- ~Mostly readable …
- Not very writable
- Magic-strings, as-a-service
- Everyone’s _ad hoc_ DSL

<small>* as a build specification language</small>

---

- Developer friction is high
- Tooling support is poor, 
- … especially for extensions and integrations

---

### Some Observations

---

- We're more attached to our actual projects than to any CI system
- developers should be able to run the build!
- this allows experimentation, use of tools
- dotnet core is cross platform, and we desire cross platform build
- Imagine being able to ... debug the build!

---

### The Idea

What if we …

- Generate the build pipeline for the CI system
- … but run our own build process,
- exposing tasks and parameters to automation,
- and wrap this in tools made for developer comfort.


##### Thankfully, someone did.

—

## Nuke.Build

