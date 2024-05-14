# filename: run-migration.py
# 
# Run the dotnet ef database commands: (Ask the user for the command)
# 1. dotnet ef migrations add <migration-name> // Create a new migration
# 2. dotnet ef database update // Apply the migrations
# 3. dotnet ef migrations script -o <output-file>
# 4. dotnet ef migrations remove
# 5. dotnet ef migrations list

# When running the script, the user will be prompted with a list of commands to choose from.
# According to the command chosen, the user will be prompted for additional information / parameters.

import os
import subprocess
import sys


def run_command(command):
    #     goto the project directory
    os.chdir("../MindCraft")
    process = subprocess.Popen(command, shell=True, stdout=subprocess.PIPE, stderr=subprocess.PIPE)
    stdout, stderr = process.communicate()
    if process.returncode != 0:
        print(f"Error: {stderr.decode('utf-8')}")
    else:
        print(f"Success: {stdout.decode('utf-8')}")
    return process.returncode


def run_migrations():
    print("Choose a command to run:")
    print("1. dotnet ef migrations add <migration-name>")
    print("2. dotnet ef database update")
    print("3. dotnet ef migrations script -o <output-file>")
    print("4. dotnet ef migrations remove")
    print("5. dotnet ef migrations list")
    command = input("Enter the command number: ")
    if command == "1":
        migration_name = input("Enter the migration name: ")
        run_command(f"dotnet ef migrations add {migration_name}")
    elif command == "2":
        run_command("dotnet ef database update")
    elif command == "3":
        output_file = input("Enter the output file: ")
        run_command(f"dotnet ef migrations script -o {output_file}")
    elif command == "4":
        run_command("dotnet ef migrations remove")
    elif command == "5":
        run_command("dotnet ef migrations list")
    else:
        print("Invalid command. Please try again.")
        run_migrations()


if __name__ == "__main__":
    try:
        run_migrations()
    except e:
        print(f"Error: {e}")

    sys.exit(0)
