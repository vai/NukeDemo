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
- Text allows process versioning

**Consistent**
- Deterministic builds provide strong guarantees

**Verifiable**
- Each commit’s output should be verifiable


---

## But, ...

---

## … YAML

---

### YAML is …

---

- ~Mostly readable
- Not very ‘writable’
- Resistant to refactoring
- Everyone’s _ad hoc_ DSL

---

- Developer friction is high
- Tooling support is poor
- … especially for extensions and integrations

---

### Some Observations

---

- Experimentation should be cheap
- Build integrations should not be arbitrarily limited

- Developers should be able to -
    - Run the build
    - Debug the build

---

### An Idea

---

What if we …

- run our own build process
- generate a CI pipeline
- exposing tasks and parameters to automation
- and wrap this all in tools made for developer comfort?

---

##### Thankfully, someone did.

---

## Nuke.Build

_[ Demo ]_

---




