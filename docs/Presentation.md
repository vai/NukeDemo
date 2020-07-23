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
- Deterministic builds are preferred

**Verifiable**
- Each commit’s output is verifiable


---

## But, ...

---

## … YAML. It’s …

---

- ~Mostly readable
- Not very ‘writable’
- Made of edge-cases
- Resistant to refactoring
- Everyone’s _ad hoc_ DSL

---

##### So, 
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

- write our own build process
- and generate a CI pipeline?


---

We could …

- expose tasks and parameters to automation
- and wrap this all in tools made for developer comfort

---

## Nuke.Build

---

Generates builds for
- Azure
- AppVeyor
- GitHub
- GitLab
- Travis
- TeamCity

---

And, 
- Build scripts for Mac, Linux, Windows
- Extensions for VS, Code, Rider, others.
- Dedicated CLI build
- Built in build script help/options

---

_[ Demo ]_

---


### References

Nuke [nuke.build](https://nuke.build/)
Demo repo [qwrk-dev/NukeDemo](https://github.com/qwrk-dev/NukeDemo)




