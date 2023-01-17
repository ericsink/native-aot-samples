#[link(name="mul", kind="raw-dylib")]
extern {
    fn multiply(a : i32, b : i32) -> i32;
}

fn main() {
    let c = unsafe { multiply(7, 6) };

    println!("{}", c);
}

