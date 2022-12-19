[![NuGet Package](https://github.com/KVSV-Github/Metaverse-Framework/actions/workflows/publish.yml/badge.svg)](https://github.com/KVSV-Github/Metaverse-Framework/actions/workflows/publish.yml)
# Metaverse Framwork

The Metaverse project allows people of any technical ability to pick up and create virtual worlds using free and open-source software. However, to develop this software, one must utilize the Metaverse framework, which is located in this repository.


## Installation

You can install the framework to any C# project using NuGet. If you're using an older version of C#, check the branches to see if there is a compatibility branch that will work with your project.

```bash
    dotnet add package Metaverse --version 1.0.1
```
https://www.nuget.org/packages/Metaverse
## Documentation

The [documentation](https://kvsv.gitbook.io/metaverse-docs/) contains most of the info needed to effectively utilize this framework. It explains the core concepts, and has many examples. Use this if you would like to contribute to the framework too.

## Usage/Examples

🚧 Under Construction 🚧

A rotator component:
```c#
public record Spin : IComponent
{
    public float speed { get; set; }
}
```

A script that rotates the entity:
```c#
using KVSV.Metaverse

public class RotateScript : IScript
{
    private List<Guid> entityIds;

    public void Start()
    {
        // Todo - get components using archetypes
        entityIds = GetEntitiesWithComponent(x);
    }

    public void Update(float deltaTime)
    {
        foreach(Guid entityId in entityIds)
        {
            Entity entity = GetEntity(entityId);
            float speed = entity.GetComponent<Spin>().Speed;
            entity.GetComponent<Transform>().Rotation += Vector3(0, speed * deltaTime, 0);
        }
    }
}
```


## Contributing

🚧 Under Construction 🚧

Contributions are always welcome!

See `contributing.md` for ways to get started.

Please adhere to this project's `code of conduct`.


## Support

For support, open up an issue using [github issues](https://github.com/KVSV-Github/Metaverse-Framework/issues).
## Authors

- [Robert Kvasov](https://github.com/robtherobot12)


## License

[GNU General Public License v3.0](https://choosealicense.com/licenses/gpl-3.0/)
