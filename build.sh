#!/bin/bash

cd rust
cargo build --release

cd ../csharp
dotnet restore

cp ../rust/target/release/libhellorust.dylib .

dotnet test