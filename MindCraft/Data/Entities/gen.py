# Our Entities:
# - UserEntity
# - AbstractResourceEntity (abstract)
# - - TextContentEntity
# - - ImageContentEntity
# - - AudioRecordingEntity
# - - TextualFileEntity [PDF, DOCX, TXT, etc.]

# create the following files / directories / subdirectories:
# - User/UserEntity.cs
# - Resource/AbstractResourceEntity.cs
# - Resource/TextContentEntity.cs
# - Resource/ImageContentEntity.cs
# - Resource/AudioRecordingEntity.cs
# - Resource/TextualFileEntity.cs

# for each entity, create the following format:
# namespace MindCraft.Data.Entities.{EntityScope};
# public class {EntityName}Entity // for non-abstract entities
# public class {EntityName}Entity : {AbstractEntityName} // for abstract entities
# {
#    // properties
#    // constructors
#    // methods
# }

############################################
import os
import sys
import re
from typing import List
from pathlib import Path

# Constants
STRUCTURE = {
    "User": {
        "AbstractEntity": None,
        "Entities": ["UserEntity"]
    },
    "Resource": {
        "AbstractEntity": "AbstractResourceEntity",
        "Entities": ["TextContentEntity", "ImageContentEntity", "AudioRecordingEntity", "TextualFileEntity"]
    }
}


# Functions
def create_entity_file(namespace: str, entity_name: str, abstract_entity: str = None, is_abstract: bool = False):
    # Create the directory if it doesn't exist
    entity_dir = Path(f"./{namespace}")
    entity_dir.mkdir(parents=True, exist_ok=True)

    # Create the file
    entity_file = entity_dir / f"{entity_name}.cs"
    with entity_file.open("w") as f:
        f.write(f"namespace MindCraft.Data.Entities.{namespace}\n")
        f.write("{\n")
        if abstract_entity:
            f.write(f"    public class {entity_name} : {abstract_entity}\n")
        elif is_abstract:
            f.write(f"    public abstract class {entity_name}\n")
        else:
            f.write(f"    public class {entity_name}\n")
        f.write("    {\n")
        f.write("        // properties\n")
        f.write("        // constructors\n")
        f.write("        // methods\n")
        f.write("    }\n")
        f.write("}\n")


def create_entities(namespace: str, abstract_entity: str, entities: List[str]):
    if abstract_entity:
        entities.append(abstract_entity)
    for entity in entities:
        is_abstract = False
        if entity == abstract_entity:
            is_abstract = True
        create_entity_file(namespace, entity, abstract_entity, is_abstract)


def main():
    for scope, data in STRUCTURE.items():
        create_entities(scope, data["AbstractEntity"], data["Entities"])
    print("Entities created successfully!")


if __name__ == "__main__":
    main()
