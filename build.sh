#!/bin/bash

cd rust
cargo build --release

cd ../csharp
dotnet restore
dotnet run

cp ../rust/target/release/libhellorust.dylib .
dotnet run