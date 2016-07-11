# Steps taken to create this project

```

mkdir dnfringe && cd dnfringe

mkdir csharp && cd csharp
dotnet new
dotnet restore
dotnet run

cd ..
cargo new rust
cd rust
cargo build

# Now, add a function to Rust


#[no_mangle]
pub extern "C" fn in_portland() -> bool {
    return true;
}

# Tell Cargo that we want a dynamic library by editing Cargo.toml to include these lines:

[lib]
name = "hellorust"
crate-type = ["dylib"]

# Now, cargo build will create rust/target/debug/libhellorust.dylib
# And cargo build --release will create rust/target/release/libhellorust.dylib

# Now, switch to csharp and edit Program.cs
cd ../csharp

#Add the P/Invoke definition

using System.Runtime.InteropServices;


[DllImport("../rust/target/debug/libhellorust.dylib")]
public static extern bool in_portland();

#Use the function:

Console.WriteLine(in_portland() ? "Hello Portland!" : "Hello World!");

#Run!

dotnet run

#Oops!

Unhandled Exception: System.DllNotFoundException

#We need the dll to be in the current folder
cp ../rust/target/debug/libhellorust.dylib .

dotnet run

> Hello Portland!

```

